﻿namespace GUI_Namespace
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadProfileButton = new System.Windows.Forms.Button();
            this.profileSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.resetProfileButton = new System.Windows.Forms.Button();
            this.trainActionSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.trainActionButton = new System.Windows.Forms.Button();
            this.driveButton = new System.Windows.Forms.Button();
            this.ctBotStatusLabel = new System.Windows.Forms.Label();
            this.forwardButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.engineStatusLabel = new System.Windows.Forms.Label();
            this.currentActionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.saveProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadProfileButton
            // 
            this.loadProfileButton.Location = new System.Drawing.Point(138, 51);
            this.loadProfileButton.Name = "loadProfileButton";
            this.loadProfileButton.Size = new System.Drawing.Size(56, 20);
            this.loadProfileButton.TabIndex = 0;
            this.loadProfileButton.Text = "Load";
            this.loadProfileButton.UseVisualStyleBackColor = true;
            this.loadProfileButton.Click += new System.EventHandler(this.loadProfileButton_Click);
            // 
            // profileSelectionComboBox
            // 
            this.profileSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSelectionComboBox.FormattingEnabled = true;
            this.profileSelectionComboBox.Items.AddRange(new object[] {
            "Testprofil 1",
            "Testprofil 2"});
            this.profileSelectionComboBox.Location = new System.Drawing.Point(11, 51);
            this.profileSelectionComboBox.Name = "profileSelectionComboBox";
            this.profileSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.profileSelectionComboBox.TabIndex = 1;
            // 
            // resetProfileButton
            // 
            this.resetProfileButton.Location = new System.Drawing.Point(261, 50);
            this.resetProfileButton.Name = "resetProfileButton";
            this.resetProfileButton.Size = new System.Drawing.Size(59, 21);
            this.resetProfileButton.TabIndex = 2;
            this.resetProfileButton.Text = "Reset";
            this.resetProfileButton.UseVisualStyleBackColor = true;
            // 
            // trainActionSelectionComboBox
            // 
            this.trainActionSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainActionSelectionComboBox.FormattingEnabled = true;
            this.trainActionSelectionComboBox.Items.AddRange(new object[] {
            "Stop",
            "Forward",
            "Left",
            "Backward",
            "Right"});
            this.trainActionSelectionComboBox.Location = new System.Drawing.Point(11, 78);
            this.trainActionSelectionComboBox.Name = "trainActionSelectionComboBox";
            this.trainActionSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.trainActionSelectionComboBox.TabIndex = 3;
            // 
            // trainActionButton
            // 
            this.trainActionButton.Location = new System.Drawing.Point(138, 78);
            this.trainActionButton.Name = "trainActionButton";
            this.trainActionButton.Size = new System.Drawing.Size(186, 21);
            this.trainActionButton.TabIndex = 4;
            this.trainActionButton.Text = "Train";
            this.trainActionButton.UseVisualStyleBackColor = true;
            this.trainActionButton.Click += new System.EventHandler(this.trainActionButton_Click);
            // 
            // driveButton
            // 
            this.driveButton.Location = new System.Drawing.Point(11, 105);
            this.driveButton.Name = "driveButton";
            this.driveButton.Size = new System.Drawing.Size(313, 51);
            this.driveButton.TabIndex = 5;
            this.driveButton.Text = "Start Driving";
            this.driveButton.UseVisualStyleBackColor = true;
            this.driveButton.Click += new System.EventHandler(this.driveButton_Click);
            // 
            // ctBotStatusLabel
            // 
            this.ctBotStatusLabel.AutoSize = true;
            this.ctBotStatusLabel.Location = new System.Drawing.Point(12, 9);
            this.ctBotStatusLabel.Name = "ctBotStatusLabel";
            this.ctBotStatusLabel.Size = new System.Drawing.Size(62, 13);
            this.ctBotStatusLabel.TabIndex = 6;
            this.ctBotStatusLabel.Text = "ctBotStatus";
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(184, 4);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(22, 18);
            this.forwardButton.TabIndex = 7;
            this.forwardButton.Text = "˄";
            this.forwardButton.UseVisualStyleBackColor = true;
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(156, 12);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(22, 18);
            this.leftButton.TabIndex = 8;
            this.leftButton.Text = "˂";
            this.leftButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(212, 12);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(22, 18);
            this.rightButton.TabIndex = 9;
            this.rightButton.Text = "˃";
            this.rightButton.UseVisualStyleBackColor = true;
            // 
            // backwardButton
            // 
            this.backwardButton.Location = new System.Drawing.Point(184, 28);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(22, 18);
            this.backwardButton.TabIndex = 10;
            this.backwardButton.Text = "˅";
            this.backwardButton.UseVisualStyleBackColor = true;
            // 
            // engineStatusLabel
            // 
            this.engineStatusLabel.AutoSize = true;
            this.engineStatusLabel.Location = new System.Drawing.Point(12, 28);
            this.engineStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.engineStatusLabel.Name = "engineStatusLabel";
            this.engineStatusLabel.Size = new System.Drawing.Size(69, 13);
            this.engineStatusLabel.TabIndex = 11;
            this.engineStatusLabel.Text = "engineStatus";
            // 
            // currentActionLabel
            // 
            this.currentActionLabel.AutoSize = true;
            this.currentActionLabel.Location = new System.Drawing.Point(12, 176);
            this.currentActionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentActionLabel.Name = "currentActionLabel";
            this.currentActionLabel.Size = new System.Drawing.Size(70, 13);
            this.currentActionLabel.TabIndex = 12;
            this.currentActionLabel.Text = "currentAction";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "testbutton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Location = new System.Drawing.Point(200, 50);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(59, 21);
            this.saveProfileButton.TabIndex = 14;
            this.saveProfileButton.Text = "Save";
            this.saveProfileButton.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 198);
            this.Controls.Add(this.saveProfileButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentActionLabel);
            this.Controls.Add(this.engineStatusLabel);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.ctBotStatusLabel);
            this.Controls.Add(this.driveButton);
            this.Controls.Add(this.trainActionButton);
            this.Controls.Add(this.trainActionSelectionComboBox);
            this.Controls.Add(this.resetProfileButton);
            this.Controls.Add(this.profileSelectionComboBox);
            this.Controls.Add(this.loadProfileButton);
            this.Name = "MainWindow";
            this.Text = "Emotiv";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadProfileButton;
        private System.Windows.Forms.ComboBox profileSelectionComboBox;
        private System.Windows.Forms.Button resetProfileButton;
        private System.Windows.Forms.ComboBox trainActionSelectionComboBox;
        private System.Windows.Forms.Button trainActionButton;
        private System.Windows.Forms.Button driveButton;
        private System.Windows.Forms.Label ctBotStatusLabel;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Label engineStatusLabel;
        private System.Windows.Forms.Label currentActionLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveProfileButton;
    }
}
