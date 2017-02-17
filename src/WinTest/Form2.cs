using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Blue.Windows;
using StickyWindowLibrary;

namespace WinTest
{
    /// <summary>
    /// Summary description for Form2.
    /// </summary>
    public class Form2 : System.Windows.Forms.Form
    {
        private StickyWindow	stickyWindow;

        private System.Windows.Forms.CheckBox checkStickToScreen;
        private System.Windows.Forms.CheckBox checkStickToOthers;
        private System.Windows.Forms.CheckBox checkStickOnResize;
        private System.Windows.Forms.CheckBox checkStickOnMove;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form2()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow( this );
            checkStickOnMove.Checked	= stickyWindow.StickOnMove;
            checkStickOnResize.Checked	= stickyWindow.StickOnResize;
            checkStickToOthers.Checked	= stickyWindow.StickToOther;
            checkStickToScreen.Checked	= stickyWindow.StickToScreen;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkStickToScreen = new System.Windows.Forms.CheckBox();
            this.checkStickToOthers = new System.Windows.Forms.CheckBox();
            this.checkStickOnResize = new System.Windows.Forms.CheckBox();
            this.checkStickOnMove = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkStickToScreen
            // 
            this.checkStickToScreen.Location = new System.Drawing.Point(26, 30);
            this.checkStickToScreen.Name = "checkStickToScreen";
            this.checkStickToScreen.Size = new System.Drawing.Size(125, 28);
            this.checkStickToScreen.TabIndex = 0;
            this.checkStickToScreen.Text = "Stick to Screen";
            this.checkStickToScreen.CheckedChanged += new System.EventHandler(this.checkStickToScreen_CheckedChanged);
            // 
            // checkStickToOthers
            // 
            this.checkStickToOthers.Location = new System.Drawing.Point(26, 67);
            this.checkStickToOthers.Name = "checkStickToOthers";
            this.checkStickToOthers.Size = new System.Drawing.Size(125, 28);
            this.checkStickToOthers.TabIndex = 1;
            this.checkStickToOthers.Text = "Stick to Others";
            this.checkStickToOthers.CheckedChanged += new System.EventHandler(this.checkStickToOthers_CheckedChanged);
            // 
            // checkStickOnResize
            // 
            this.checkStickOnResize.Location = new System.Drawing.Point(26, 141);
            this.checkStickOnResize.Name = "checkStickOnResize";
            this.checkStickOnResize.Size = new System.Drawing.Size(125, 27);
            this.checkStickOnResize.TabIndex = 2;
            this.checkStickOnResize.Text = "Stick on Resize";
            this.checkStickOnResize.CheckedChanged += new System.EventHandler(this.checkStickOnResize_CheckedChanged);
            // 
            // checkStickOnMove
            // 
            this.checkStickOnMove.Location = new System.Drawing.Point(26, 178);
            this.checkStickOnMove.Name = "checkStickOnMove";
            this.checkStickOnMove.Size = new System.Drawing.Size(125, 27);
            this.checkStickOnMove.TabIndex = 3;
            this.checkStickOnMove.Text = "Stick On Move";
            this.checkStickOnMove.CheckedChanged += new System.EventHandler(this.checkStickOnMove_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.checkStickOnMove);
            this.Controls.Add(this.checkStickOnResize);
            this.Controls.Add(this.checkStickToOthers);
            this.Controls.Add(this.checkStickToScreen);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void Form2_Load(object sender, System.EventArgs e)
        {
        }

        private void checkStickToScreen_CheckedChanged(object sender, System.EventArgs e)
        {
            stickyWindow.StickToScreen = checkStickToScreen.Checked;
        }

        private void checkStickToOthers_CheckedChanged(object sender, System.EventArgs e)
        {
            stickyWindow.StickToOther = checkStickToOthers.Checked;
        }

        private void checkStickOnResize_CheckedChanged(object sender, System.EventArgs e)
        {
            stickyWindow.StickOnResize = checkStickOnResize.Checked;
        }

        private void checkStickOnMove_CheckedChanged(object sender, System.EventArgs e)
        {
            stickyWindow.StickOnMove = checkStickOnMove.Checked;
        }
    }
}