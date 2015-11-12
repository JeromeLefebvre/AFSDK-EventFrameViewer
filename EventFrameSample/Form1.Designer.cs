namespace EventFrameViewer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codes were created by Windows Form Designer

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.piSystemPicker1 = new OSIsoft.AF.UI.PISystemPicker();
            this.afTreeView1 = new OSIsoft.AF.UI.AFTreeView();
            this.afDatabasePicker1 = new OSIsoft.AF.UI.AFDatabasePicker();
            this.GetEventFrames = new System.Windows.Forms.Button();
            this.EndTimeTextBox = new System.Windows.Forms.TextBox();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.EFListView = new System.Windows.Forms.ListView();
            this.EventFrameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EFStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EFEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EFAttrView = new System.Windows.Forms.ListView();
            this.Attribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddTrendButton = new System.Windows.Forms.Button();
            this.ClearTrendButton = new System.Windows.Forms.Button();
            this.EventFrameTemplateComboBox = new System.Windows.Forms.ComboBox();
            this.EventFrameTemplateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // piSystemPicker1
            // 
            this.piSystemPicker1.AccessibleDescription = "Select PI System";
            this.piSystemPicker1.AccessibleName = "Select PI System";
            this.piSystemPicker1.Caption = "エラー";
            this.piSystemPicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.piSystemPicker1.Location = new System.Drawing.Point(12, 10);
            this.piSystemPicker1.LoginPromptSetting = OSIsoft.AF.UI.PISystemPicker.LoginPromptSettingOptions.Default;
            this.piSystemPicker1.Name = "piSystemPicker1";
            this.piSystemPicker1.ShowBegin = false;
            this.piSystemPicker1.ShowDelete = false;
            this.piSystemPicker1.ShowEnd = false;
            this.piSystemPicker1.ShowFind = false;
            this.piSystemPicker1.ShowImages = false;
            this.piSystemPicker1.ShowNavigation = false;
            this.piSystemPicker1.ShowNew = false;
            this.piSystemPicker1.ShowNext = false;
            this.piSystemPicker1.ShowNoEntries = false;
            this.piSystemPicker1.ShowPrevious = false;
            this.piSystemPicker1.ShowProperties = false;
            this.piSystemPicker1.Size = new System.Drawing.Size(211, 20);
            this.piSystemPicker1.TabIndex = 0;
            this.piSystemPicker1.ConnectionChange += new OSIsoft.AF.UI.ConnectionChangeEventHandler(this.piSystemPicker1_ConnectionChange);
            // 
            // afTreeView1
            // 
            this.afTreeView1.HideSelection = false;
            this.afTreeView1.Location = new System.Drawing.Point(12, 69);
            this.afTreeView1.Name = "afTreeView1";
            this.afTreeView1.ShowNodeToolTips = true;
            this.afTreeView1.Size = new System.Drawing.Size(211, 588);
            this.afTreeView1.TabIndex = 1;
            this.afTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.afTreeView1_AfterSelect);
            // 
            // afDatabasePicker1
            // 
            this.afDatabasePicker1.AccessibleDescription = "Specify Database";
            this.afDatabasePicker1.AccessibleName = "Specify Database";
            this.afDatabasePicker1.Caption = "エラー";
            this.afDatabasePicker1.Location = new System.Drawing.Point(12, 41);
            this.afDatabasePicker1.Name = "afDatabasePicker1";
            this.afDatabasePicker1.ShowBegin = false;
            this.afDatabasePicker1.ShowDelete = false;
            this.afDatabasePicker1.ShowEnd = false;
            this.afDatabasePicker1.ShowFind = false;
            this.afDatabasePicker1.ShowImages = false;
            this.afDatabasePicker1.ShowNavigation = false;
            this.afDatabasePicker1.ShowNew = false;
            this.afDatabasePicker1.ShowNext = false;
            this.afDatabasePicker1.ShowNoEntries = false;
            this.afDatabasePicker1.ShowPrevious = false;
            this.afDatabasePicker1.ShowProperties = false;
            this.afDatabasePicker1.Size = new System.Drawing.Size(211, 20);
            this.afDatabasePicker1.TabIndex = 2;
            this.afDatabasePicker1.SelectionChange += new OSIsoft.AF.UI.SelectionChangeEventHandler(this.afDatabasePicker1_SelectionChange);
            // 
            // GetEventFrames
            // 
            this.GetEventFrames.Location = new System.Drawing.Point(967, 12);
            this.GetEventFrames.Name = "GetEventFrames";
            this.GetEventFrames.Size = new System.Drawing.Size(120, 23);
            this.GetEventFrames.TabIndex = 3;
            this.GetEventFrames.Text = "Get Event Frames";
            this.GetEventFrames.UseVisualStyleBackColor = true;
            this.GetEventFrames.Click += new System.EventHandler(this.GetEventFrames_Click);
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(856, 14);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(72, 19);
            this.EndTimeTextBox.TabIndex = 43;
            this.EndTimeTextBox.Text = "*";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(797, 17);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.EndTimeLabel.TabIndex = 45;
            this.EndTimeLabel.Text = "End Time";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(632, 17);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(59, 12);
            this.StartTimeLabel.TabIndex = 44;
            this.StartTimeLabel.Text = "Start Time";
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(697, 14);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(72, 19);
            this.StartTimeTextBox.TabIndex = 42;
            this.StartTimeTextBox.Text = "*-2h";
            // 
            // EFListView
            // 
            this.EFListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventFrameName,
            this.Duration,
            this.EFStartTime,
            this.EFEndTime,
            this.GUID});
            this.EFListView.FullRowSelect = true;
            this.EFListView.HideSelection = false;
            this.EFListView.Location = new System.Drawing.Point(242, 39);
            this.EFListView.Name = "EFListView";
            this.EFListView.Size = new System.Drawing.Size(1019, 137);
            this.EFListView.TabIndex = 46;
            this.EFListView.UseCompatibleStateImageBehavior = false;
            this.EFListView.View = System.Windows.Forms.View.Details;
            this.EFListView.SelectedIndexChanged += new System.EventHandler(this.EFListView_SelectedIndexChanged);
            // 
            // EventFrameName
            // 
            this.EventFrameName.Text = "Event Frame Name";
            this.EventFrameName.Width = 342;
            // 
            // Duration
            // 
            this.Duration.Text = "Duration";
            this.Duration.Width = 112;
            // 
            // EFStartTime
            // 
            this.EFStartTime.Text = "Start Time";
            this.EFStartTime.Width = 172;
            // 
            // EFEndTime
            // 
            this.EFEndTime.Text = "End Time";
            this.EFEndTime.Width = 154;
            // 
            // GUID
            // 
            this.GUID.Text = "GUID";
            this.GUID.Width = 307;
            // 
            // chart1
            // 
            this.chart1.AllowDrop = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(242, 329);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1019, 328);
            this.chart1.TabIndex = 47;
            this.chart1.Text = "chart1";
            // 
            // EFAttrView
            // 
            this.EFAttrView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Attribute,
            this.Value});
            this.EFAttrView.FullRowSelect = true;
            this.EFAttrView.HideSelection = false;
            this.EFAttrView.Location = new System.Drawing.Point(242, 182);
            this.EFAttrView.Name = "EFAttrView";
            this.EFAttrView.Size = new System.Drawing.Size(1019, 112);
            this.EFAttrView.TabIndex = 48;
            this.EFAttrView.UseCompatibleStateImageBehavior = false;
            this.EFAttrView.View = System.Windows.Forms.View.Details;
            // 
            // Attribute
            // 
            this.Attribute.Text = "Attribute Name";
            this.Attribute.Width = 180;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 180;
            // 
            // AddTrendButton
            // 
            this.AddTrendButton.Location = new System.Drawing.Point(242, 300);
            this.AddTrendButton.Name = "AddTrendButton";
            this.AddTrendButton.Size = new System.Drawing.Size(87, 23);
            this.AddTrendButton.TabIndex = 49;
            this.AddTrendButton.Text = "Add Trend";
            this.AddTrendButton.UseVisualStyleBackColor = true;
            this.AddTrendButton.Click += new System.EventHandler(this.AddTrendButton_Click);
            // 
            // ClearTrendButton
            // 
            this.ClearTrendButton.Location = new System.Drawing.Point(1149, 300);
            this.ClearTrendButton.Name = "ClearTrendButton";
            this.ClearTrendButton.Size = new System.Drawing.Size(112, 23);
            this.ClearTrendButton.TabIndex = 50;
            this.ClearTrendButton.Text = "Clear Trends";
            this.ClearTrendButton.UseVisualStyleBackColor = true;
            this.ClearTrendButton.Click += new System.EventHandler(this.ClearTrendButton_Click);
            // 
            // EventFrameTemplateComboBox
            // 
            this.EventFrameTemplateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventFrameTemplateComboBox.FormattingEnabled = true;
            this.EventFrameTemplateComboBox.Location = new System.Drawing.Point(367, 12);
            this.EventFrameTemplateComboBox.Name = "EventFrameTemplateComboBox";
            this.EventFrameTemplateComboBox.Size = new System.Drawing.Size(211, 20);
            this.EventFrameTemplateComboBox.TabIndex = 51;
            // 
            // EventFrameTemplateLabel
            // 
            this.EventFrameTemplateLabel.AutoSize = true;
            this.EventFrameTemplateLabel.Location = new System.Drawing.Point(240, 15);
            this.EventFrameTemplateLabel.Name = "EventFrameTemplateLabel";
            this.EventFrameTemplateLabel.Size = new System.Drawing.Size(121, 12);
            this.EventFrameTemplateLabel.TabIndex = 52;
            this.EventFrameTemplateLabel.Text = "Event Frame Template";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 667);
            this.Controls.Add(this.EventFrameTemplateLabel);
            this.Controls.Add(this.EventFrameTemplateComboBox);
            this.Controls.Add(this.ClearTrendButton);
            this.Controls.Add(this.AddTrendButton);
            this.Controls.Add(this.EFAttrView);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.EFListView);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.EndTimeTextBox);
            this.Controls.Add(this.StartTimeTextBox);
            this.Controls.Add(this.GetEventFrames);
            this.Controls.Add(this.afDatabasePicker1);
            this.Controls.Add(this.afTreeView1);
            this.Controls.Add(this.piSystemPicker1);
            this.Name = "Form1";
            this.Text = "Event Frame Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OSIsoft.AF.UI.PISystemPicker piSystemPicker1;
        private OSIsoft.AF.UI.AFTreeView afTreeView1;
        private OSIsoft.AF.UI.AFDatabasePicker afDatabasePicker1;
        private System.Windows.Forms.Button GetEventFrames;
        private System.Windows.Forms.TextBox EndTimeTextBox;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.ListView EFListView;
        private System.Windows.Forms.ColumnHeader EventFrameName;
        private System.Windows.Forms.ColumnHeader EFStartTime;
        private System.Windows.Forms.ColumnHeader EFEndTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListView EFAttrView;
        private System.Windows.Forms.ColumnHeader Attribute;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader GUID;
        private System.Windows.Forms.Button AddTrendButton;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.Button ClearTrendButton;
        private System.Windows.Forms.ComboBox EventFrameTemplateComboBox;
        private System.Windows.Forms.Label EventFrameTemplateLabel;
    }
}

