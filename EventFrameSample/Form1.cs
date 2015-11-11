using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSIsoft.AF;
using OSIsoft.AF.UI;
using OSIsoft.AF.Time;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using OSIsoft.AF.EventFrame;

namespace EventFrameViewer
{

    public partial class Form1 : Form
    {
        public AFDatabase myAFDatabase;
        public PISystem myAFServer;
        public AFElement myElement;
        public PIServer myPIServer;
        public AFElementTemplates myElementTemplates;
        public AFElementTemplate myElementTemplate;
        public TimeSpan maxtimedif = new TimeSpan(0);
        public Int32 num = 1;
        public Int32 Errchk = 0;
        public Form1()
        {
            InitializeComponent();
            afDatabasePicker1.SystemPicker = piSystemPicker1;
        }

        public void piSystemPicker1_ConnectionChange(object sender, OSIsoft.AF.UI.SelectionChangeEventArgs e)
        {

            //Set AF Server to the current selected object
            myAFServer = (PISystem)e.SelectedObject;
            AFDatabases databaseList = myAFServer.Databases;
        }

        public void afDatabasePicker1_SelectionChange(object sender, OSIsoft.AF.UI.SelectionChangeEventArgs e)
        {
            afTreeView1.AFRoot = null;
            myAFDatabase = (AFDatabase)e.SelectedObject;
            if (myAFDatabase != null)
            {
                //Clear ListBoxes
                EFListView.Items.Clear();
                EFAttrView.Items.Clear();
                chart1.Series.Clear();

                //Populate the AF Treeview with Elements only.
                afTreeView1.AFRoot = myAFDatabase.Elements;
                //Put Element Template Name to ComboBox
                EventFrameTemplateComboBox.Items.Clear();
                myElementTemplates = myAFDatabase.ElementTemplates;
                foreach (AFElementTemplate myElementTemplate in myElementTemplates)
                {
                    if (myElementTemplate.InstanceType.Name == "AFEventFrame")
                    {
                        EventFrameTemplateComboBox.Items.Add(myElementTemplate.Name);
                        //Adding selected item
                        EventFrameTemplateComboBox.SelectedItem = myElementTemplate.Name;
                    }
                }
            }
        }

        private void GetEventFrames_Click(object sender, EventArgs e)
        {
            if (afTreeView1.AFSelectedPath == afTreeView1.AFRootPath)
            {
                MessageBox.Show("Please Select Element from ElementTree");
            }
            else
            {
                //Clear ListBoxes
                EFListView.Items.Clear();
                EFAttrView.Items.Clear();

                myElement = myAFDatabase.Elements[afTreeView1.AFSelectedPath];
                AFAttributes myAFAttributes = myElement.Attributes;
                if (myAFAttributes.Count == 0)
                {
                    //MessageBox.Show("No Attribute Found");
                }
                else
                {
                    AFNamedCollectionList<AFEventFrame> EFs;
                    String SearchString = "ElementName:"+myElement.Name;
                    //Use EventFrameTemplate for searching
                    myElementTemplate = myAFDatabase.ElementTemplates[EventFrameTemplateComboBox.SelectedItem.ToString()];
                    EFs = myElement.GetEventFrames(AFSearchMode.Overlapped,StartTimeTextBox.Text,EndTimeTextBox.Text,"",null,myElementTemplate,AFSortField.StartTime,AFSortOrder.Descending,0,1000);
                    foreach (AFEventFrame EF in EFs)
                    {
                        string[] displayvalues = new string[5];
                        displayvalues[0] = EF.Name;
                        TimeSpan EFDuration = EF.EndTime - EF.StartTime;
                        //Not ending eventframe returns 9999 year.
                        if (EFDuration.TotalSeconds < 5000000)
                        {
                            displayvalues[1] = EFDuration.TotalSeconds.ToString();
                        }
                        else
                        {
                            displayvalues[1] = "-";
                        }
                        displayvalues[2] = EF.StartTime.LocalTime.ToString();
                        displayvalues[3] = EF.EndTime.LocalTime.ToString();
                        displayvalues[4] = EF.UniqueID;
                        ListViewItem lvi = new ListViewItem(displayvalues);
                        EFListView.Items.Add(lvi);
                    }
                }
            }
        }

        private void EFListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (EFListView.SelectedItems.Count == 1 )
            {
                EFAttrView.Items.Clear();
                ListViewItem SelectedEF = EFListView.SelectedItems[0];
                
                Guid myEFGUID = Guid.Empty;
                String myguidstring = SelectedEF.SubItems[4].Text;
                
                try { myEFGUID = Guid.Parse(myguidstring); }
                catch { MessageBox.Show("Cannot convert GUID"); }
                
                AFEventFrame myEF = AFEventFrame.FindEventFrame(myAFServer, myEFGUID);
                AFAttributes myEFAttrs = myEF.Attributes;
                
                foreach (AFAttribute attr in myEFAttrs)
                {
                    string[] displayvalues = new string[4];
                    displayvalues[0] = attr.Name;
                    
                    try
                    {
                        displayvalues[1] = attr.Data.RecordedValue(new AFTime(myEF.StartTime),AFRetrievalMode.AtOrAfter,null).ToString();
                    }
                    catch
                    {
                        try
                        {
                            displayvalues[1] = attr.GetValue().ToString();
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                    }
                    displayvalues[2] = myEF.Name;
                    displayvalues[3] = myEF.UniqueID;
                    ListViewItem lvi = new ListViewItem(displayvalues);
                    EFAttrView.Items.Add(lvi);
                }
                 
            }
        }

        private void AddTrendButton_Click(object sender, EventArgs e)
        {
            if (EFListView.SelectedItems.Count >= 1 && EFAttrView.SelectedItems.Count >= 1)
            {
                for (int i = 0; i < EFListView.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < EFAttrView.SelectedItems.Count; j++)
                    {
                        ListViewItem SelectedEF = EFListView.SelectedItems[i];
                        ListViewItem SelectedEFattr = EFAttrView.SelectedItems[j];
                        //Get EFName and Attribute Name
                        String EFName = SelectedEF.SubItems[0].Text;
                        String EFattrName = SelectedEFattr.SubItems[0].Text;
                        String title = num+ "_" + EFName + " : " + EFattrName;
                        
                        //Create GUID for Selected Event Frame
                        Guid myEFGUID = Guid.Empty;
                        String myguidstring = SelectedEF.SubItems[4].Text;
                        try { myEFGUID = Guid.Parse(myguidstring); }
                        catch { MessageBox.Show("Cannot convert GUID"); }

                        //Find Selected Event Frame
                        AFEventFrame myEF = AFEventFrame.FindEventFrame(myAFServer, myEFGUID);
                        AFTime startTime = myEF.StartTime;
                        AFTime endTime = myEF.EndTime;
                        //Set endtime as now for not finishing event frame
                        if (endTime > new AFTime("2099/1/1"))
                        {
                            endTime = DateTime.Now;
                        }
                        AFTimeRange timerange = new AFTimeRange(startTime, endTime);
                        //Find Selected Attribute
                        AFAttribute myEFAttr = myEF.Attributes[SelectedEFattr.Text];

                        DateTime trendstarttime = new DateTime(0);
                        //Check time difference between start time and end time
                        TimeSpan timedif = endTime - startTime;
                        try
                        {
                            AFValues vals = myEFAttr.Data.PlotValues(timerange, 100, null);
                            Int32 chk = 0;
                            foreach (AFValue val in vals)
                            {
                                //Sometimes System.InvalidOperationException happens.
                                Type t = val.Value.GetType();
                                if (t.FullName != "System.InvalidOperationException")
                                {
                                    if (chk == 0)
                                    {
                                        //Add line to chart1
                                        try
                                        {
                                            //add trend to chart1
                                            chart1.Series.Add(title);
                                            chart1.Series[title].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                            chart1.Series[title].BorderWidth = 2; // Line width
                                            chart1.Series[title].ToolTip = "#SERIESNAME\r\nValue : #VALY{N2}\r\nTime : #VALX{N0}";
                                            chart1.ChartAreas[0].AxisX.Title = "Seconds";
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                            return;
                                        }
                                        trendstarttime = val.Timestamp.LocalTime;
                                    }
                                    timedif = val.Timestamp.LocalTime - trendstarttime;
                                    
                                    //Displaying EnumerationSet value as number
                                    if (t.FullName == "OSIsoft.AF.Asset.AFEnumerationValue")
                                    {
                                        //Errchk = 1;
                                        AFEnumerationValue MyEnumerationValue = (AFEnumerationValue)val.Value;
                                        // last value will be returned as 248. So ignore it
                                        if (MyEnumerationValue.Value != 248)
                                        {
                                            chart1.Series[title].Points.AddXY(timedif.TotalSeconds, MyEnumerationValue.Value.ToString());
                                        }
                                    }
                                    else
                                    {
                                        chart1.Series[title].Points.AddXY(timedif.TotalSeconds, val.Value.ToString());
                                    }
                                    chk = 1; 
                                }
                                else
                                {
                                    Errchk = 1;
                                    //Write code for System.InvalidOperationException - Currently ignore it
                                    //AFValue val2 = myEFAttr.GetValue();
                                    //timedif = endTime - startTime;
                                    //chart1.Series[title].Points.AddXY(0, val2.Value.ToString());
                                    //chart1.Series[title].Points.AddXY(timedif.TotalSeconds, val2.Value.ToString());
                                }
                            }
                        }
                        catch
                        {
                            Errchk = 1;
                            //If error happens, write code - Currently ignore it
                            //AFValue val = myEFAttr.GetValue();
                            //chart1.Series[title].Points.AddXY(0, val.Value.ToString());
                            //chart1.Series[title].Points.AddXY(timedif.TotalSeconds, val.Value.ToString());
                        }
                        if (Errchk == 0)
                        {
                            //If there is no error, Set minimum and maximum time
                            chart1.ChartAreas[0].AxisX.Minimum = 0;
                            if (maxtimedif > timedif)
                            {
                                chart1.ChartAreas[0].AxisX.Maximum = maxtimedif.TotalSeconds;
                            }
                            else
                            {
                                chart1.ChartAreas[0].AxisX.Maximum = timedif.TotalSeconds;
                                maxtimedif = timedif;
                            }
                            ++num;
                        }
                        Errchk = 0;                       
                    }
                }
            }
        }

        private void ClearTrendButton_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            maxtimedif =  new TimeSpan(0);
            num = 1;
        }

        private void afTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Clear ListBoxes
            EFListView.Items.Clear();
            EFAttrView.Items.Clear();
        }
    }
}