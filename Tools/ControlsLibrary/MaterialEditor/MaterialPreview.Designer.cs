﻿// Copyright 2015 XLGAMES Inc.
//
// Distributed under the MIT License (See
// accompanying file "LICENSE" or the website
// http://www.opensource.org/licenses/mit-license.php)

namespace ControlsLibrary.MaterialEditor
{
    partial class MaterialPreview
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                visSettings.Dispose();
                visLayer.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this._lightingType = new System.Windows.Forms.ComboBox();
            this._geoType = new System.Windows.Forms.ComboBox();
            this.preview = new LayerControl(); 
            this._resetCamera = new System.Windows.Forms.Button();
            this._environment = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._resetCamera);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this._lightingType);
            this.groupBox1.Controls.Add(this._geoType);
            this.groupBox1.Controls.Add(this._environment);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(554, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(6, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Draw Grid";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // _lightingType
            // 
            this._lightingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._lightingType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lightingType.FormattingEnabled = true;
            this._lightingType.Location = new System.Drawing.Point(5, 46);
            this._lightingType.Size = new System.Drawing.Size(155, 21);
            this._lightingType.TabIndex = 1;
            // 
            // _geoType
            // 
            this._geoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._geoType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._geoType.FormattingEnabled = true;
            this._geoType.Location = new System.Drawing.Point(5, 19);
            this._geoType.Size = new System.Drawing.Size(155, 21);
            this._geoType.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(4, 4);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(544, 339);
            this.preview.TabIndex = 1;
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)));
            // 
            // _resetCamera
            // 
            this._resetCamera.Location = new System.Drawing.Point(5, 97);
            this._resetCamera.Name = "_resetCamera";
            this._resetCamera.Size = new System.Drawing.Size(155, 23);
            this._resetCamera.TabIndex = 3;
            this._resetCamera.Text = "Reset Camera";
            this._resetCamera.UseVisualStyleBackColor = true;
            this._resetCamera.Click += new System.EventHandler(this._resetCamera_Click);
            // 
            // _environment
            // 
            this._environment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._environment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._environment.FormattingEnabled = true;
            this._environment.Location = new System.Drawing.Point(5, 123);
            this._environment.Size = new System.Drawing.Size(155, 21);
            this._environment.TabIndex = 4;
            this._environment.Visible = false;
            // 
            // MaterialPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.preview);
            this.Controls.Add(this.groupBox1);
            this.Name = "MaterialPreview";
            this.Size = new System.Drawing.Size(723, 346);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _geoType;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox _lightingType;
        private LayerControl preview;
        private System.Windows.Forms.Button _resetCamera;
        private System.Windows.Forms.ComboBox _environment;
    }
}