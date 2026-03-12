namespace EurofighterCockpit.Slides
{
    partial class SlideJoystick
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideJoystick));
            this.bpb_airbrake = new EurofighterCockpit.BetterProgressBar();
            this.bpb_trigger = new EurofighterCockpit.BetterProgressBar();
            this.bpb_gear = new EurofighterCockpit.BetterProgressBar();
            this.bpb_rudderReset = new EurofighterCockpit.BetterProgressBar();
            this.bpb_rudderL = new EurofighterCockpit.BetterProgressBar();
            this.bpb_rudderR = new EurofighterCockpit.BetterProgressBar();
            this.bpb_throttle = new EurofighterCockpit.BetterProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bpb_joystickTorque = new EurofighterCockpit.BetterProgressBar();
            this.betterProgressBar1 = new EurofighterCockpit.BetterProgressBar();
            this.bpb_joystickXpos = new EurofighterCockpit.BetterProgressBar();
            this.bpb_joystickXneg = new EurofighterCockpit.BetterProgressBar();
            this.bpb_joystickYpos = new EurofighterCockpit.BetterProgressBar();
            this.bpb_joystickYneg = new EurofighterCockpit.BetterProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bpb_landingLights = new EurofighterCockpit.BetterProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.bpb_positionLights = new EurofighterCockpit.BetterProgressBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bpb_airbrake
            // 
            this.bpb_airbrake.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_airbrake.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_airbrake.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_airbrake.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_airbrake.Location = new System.Drawing.Point(830, 550);
            this.bpb_airbrake.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_airbrake.Name = "bpb_airbrake";
            this.bpb_airbrake.Progress = 0;
            this.bpb_airbrake.Size = new System.Drawing.Size(80, 200);
            this.bpb_airbrake.TabIndex = 101;
            // 
            // bpb_trigger
            // 
            this.bpb_trigger.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_trigger.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_trigger.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_trigger.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_trigger.Location = new System.Drawing.Point(830, 170);
            this.bpb_trigger.Margin = new System.Windows.Forms.Padding(60);
            this.bpb_trigger.Name = "bpb_trigger";
            this.bpb_trigger.Progress = 0;
            this.bpb_trigger.Size = new System.Drawing.Size(80, 200);
            this.bpb_trigger.TabIndex = 79;
            // 
            // bpb_gear
            // 
            this.bpb_gear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_gear.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_gear.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_gear.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_gear.Location = new System.Drawing.Point(980, 920);
            this.bpb_gear.Margin = new System.Windows.Forms.Padding(8);
            this.bpb_gear.Name = "bpb_gear";
            this.bpb_gear.Progress = 0;
            this.bpb_gear.Size = new System.Drawing.Size(120, 80);
            this.bpb_gear.TabIndex = 85;
            // 
            // bpb_rudderReset
            // 
            this.bpb_rudderReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_rudderReset.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_rudderReset.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_rudderReset.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_rudderReset.Location = new System.Drawing.Point(1040, 650);
            this.bpb_rudderReset.Margin = new System.Windows.Forms.Padding(30);
            this.bpb_rudderReset.Name = "bpb_rudderReset";
            this.bpb_rudderReset.Progress = 0;
            this.bpb_rudderReset.Size = new System.Drawing.Size(100, 100);
            this.bpb_rudderReset.TabIndex = 84;
            // 
            // bpb_rudderL
            // 
            this.bpb_rudderL.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_rudderL.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_rudderL.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_rudderL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_rudderL.Location = new System.Drawing.Point(1040, 210);
            this.bpb_rudderL.Margin = new System.Windows.Forms.Padding(30);
            this.bpb_rudderL.Name = "bpb_rudderL";
            this.bpb_rudderL.Progress = 0;
            this.bpb_rudderL.Size = new System.Drawing.Size(100, 100);
            this.bpb_rudderL.TabIndex = 83;
            // 
            // bpb_rudderR
            // 
            this.bpb_rudderR.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_rudderR.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_rudderR.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_rudderR.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_rudderR.Location = new System.Drawing.Point(1040, 430);
            this.bpb_rudderR.Margin = new System.Windows.Forms.Padding(30);
            this.bpb_rudderR.Name = "bpb_rudderR";
            this.bpb_rudderR.Progress = 0;
            this.bpb_rudderR.Size = new System.Drawing.Size(100, 100);
            this.bpb_rudderR.TabIndex = 81;
            // 
            // bpb_throttle
            // 
            this.bpb_throttle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_throttle.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_throttle.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_throttle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_throttle.Location = new System.Drawing.Point(1260, 170);
            this.bpb_throttle.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_throttle.Name = "bpb_throttle";
            this.bpb_throttle.Progress = 0;
            this.bpb_throttle.Size = new System.Drawing.Size(190, 580);
            this.bpb_throttle.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(140, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(580, 70);
            this.label6.TabIndex = 75;
            this.label6.Text = "Joystick";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(550, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 80);
            this.label8.TabIndex = 38;
            this.label8.Text = "Twist right";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(210, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 80);
            this.label7.TabIndex = 31;
            this.label7.Text = "Twist left";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // bpb_joystickTorque
            // 
            this.bpb_joystickTorque.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_joystickTorque.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(91)))));
            this.bpb_joystickTorque.Direction = EurofighterCockpit.Direction.rightToLeft;
            this.bpb_joystickTorque.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_joystickTorque.Location = new System.Drawing.Point(210, 280);
            this.bpb_joystickTorque.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_joystickTorque.Name = "bpb_joystickTorque";
            this.bpb_joystickTorque.Progress = 0;
            this.bpb_joystickTorque.Size = new System.Drawing.Size(100, 50);
            this.bpb_joystickTorque.TabIndex = 37;
            this.bpb_joystickTorque.Visible = false;
            // 
            // betterProgressBar1
            // 
            this.betterProgressBar1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.betterProgressBar1.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(91)))));
            this.betterProgressBar1.Direction = EurofighterCockpit.Direction.leftToRight;
            this.betterProgressBar1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.betterProgressBar1.Location = new System.Drawing.Point(550, 280);
            this.betterProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.betterProgressBar1.Name = "betterProgressBar1";
            this.betterProgressBar1.Progress = 0;
            this.betterProgressBar1.Size = new System.Drawing.Size(100, 50);
            this.betterProgressBar1.TabIndex = 36;
            this.betterProgressBar1.Visible = false;
            // 
            // bpb_joystickXpos
            // 
            this.bpb_joystickXpos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_joystickXpos.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_joystickXpos.Direction = EurofighterCockpit.Direction.leftToRight;
            this.bpb_joystickXpos.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_joystickXpos.Location = new System.Drawing.Point(470, 420);
            this.bpb_joystickXpos.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_joystickXpos.Name = "bpb_joystickXpos";
            this.bpb_joystickXpos.Progress = 0;
            this.bpb_joystickXpos.Size = new System.Drawing.Size(250, 80);
            this.bpb_joystickXpos.TabIndex = 31;
            // 
            // bpb_joystickXneg
            // 
            this.bpb_joystickXneg.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_joystickXneg.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_joystickXneg.Direction = EurofighterCockpit.Direction.rightToLeft;
            this.bpb_joystickXneg.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_joystickXneg.Location = new System.Drawing.Point(140, 420);
            this.bpb_joystickXneg.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_joystickXneg.Name = "bpb_joystickXneg";
            this.bpb_joystickXneg.Progress = 0;
            this.bpb_joystickXneg.Size = new System.Drawing.Size(250, 80);
            this.bpb_joystickXneg.TabIndex = 32;
            // 
            // bpb_joystickYpos
            // 
            this.bpb_joystickYpos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_joystickYpos.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_joystickYpos.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_joystickYpos.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_joystickYpos.Location = new System.Drawing.Point(390, 170);
            this.bpb_joystickYpos.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_joystickYpos.Name = "bpb_joystickYpos";
            this.bpb_joystickYpos.Progress = 0;
            this.bpb_joystickYpos.Size = new System.Drawing.Size(80, 250);
            this.bpb_joystickYpos.TabIndex = 34;
            // 
            // bpb_joystickYneg
            // 
            this.bpb_joystickYneg.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_joystickYneg.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_joystickYneg.Direction = EurofighterCockpit.Direction.topToBottom;
            this.bpb_joystickYneg.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_joystickYneg.Location = new System.Drawing.Point(390, 500);
            this.bpb_joystickYneg.Margin = new System.Windows.Forms.Padding(0);
            this.bpb_joystickYneg.Name = "bpb_joystickYneg";
            this.bpb_joystickYneg.Progress = 0;
            this.bpb_joystickYneg.Size = new System.Drawing.Size(80, 250);
            this.bpb_joystickYneg.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(780, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 70);
            this.label1.TabIndex = 103;
            this.label1.Text = "Trigger";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(780, 460);
            this.label2.Margin = new System.Windows.Forms.Padding(80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 70);
            this.label2.TabIndex = 104;
            this.label2.Text = "Airbrake";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1260, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 70);
            this.label3.TabIndex = 105;
            this.label3.Text = "Schub";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1010, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 70);
            this.label4.TabIndex = 106;
            this.label4.Text = "Ruder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1040, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 40);
            this.label5.TabIndex = 107;
            this.label5.Text = "Links";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1040, 380);
            this.label9.Margin = new System.Windows.Forms.Padding(10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 40);
            this.label9.TabIndex = 108;
            this.label9.Text = "Rechts";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1040, 600);
            this.label10.Margin = new System.Windows.Forms.Padding(10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 40);
            this.label10.TabIndex = 109;
            this.label10.Text = "Reset";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(440, 870);
            this.label11.Margin = new System.Windows.Forms.Padding(10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 40);
            this.label11.TabIndex = 111;
            this.label11.Text = "Landing";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bpb_landingLights
            // 
            this.bpb_landingLights.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_landingLights.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_landingLights.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_landingLights.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_landingLights.Location = new System.Drawing.Point(440, 920);
            this.bpb_landingLights.Margin = new System.Windows.Forms.Padding(30);
            this.bpb_landingLights.Name = "bpb_landingLights";
            this.bpb_landingLights.Progress = 0;
            this.bpb_landingLights.Size = new System.Drawing.Size(120, 80);
            this.bpb_landingLights.TabIndex = 110;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(660, 870);
            this.label12.Margin = new System.Windows.Forms.Padding(10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 40);
            this.label12.TabIndex = 113;
            this.label12.Text = "Position";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bpb_positionLights
            // 
            this.bpb_positionLights.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bpb_positionLights.ColorProg = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(199)))));
            this.bpb_positionLights.Direction = EurofighterCockpit.Direction.bottomToTop;
            this.bpb_positionLights.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bpb_positionLights.Location = new System.Drawing.Point(660, 920);
            this.bpb_positionLights.Margin = new System.Windows.Forms.Padding(30);
            this.bpb_positionLights.Name = "bpb_positionLights";
            this.bpb_positionLights.Progress = 0;
            this.bpb_positionLights.Size = new System.Drawing.Size(120, 80);
            this.bpb_positionLights.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(440, 790);
            this.label13.Margin = new System.Windows.Forms.Padding(80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(340, 70);
            this.label13.TabIndex = 114;
            this.label13.Text = "Beleuchtung";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Leelawadee UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(940, 850);
            this.label14.Margin = new System.Windows.Forms.Padding(80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(200, 70);
            this.label14.TabIndex = 115;
            this.label14.Text = "Fahrwerk";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlideJoystick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bpb_positionLights);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bpb_landingLights);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bpb_airbrake);
            this.Controls.Add(this.bpb_joystickTorque);
            this.Controls.Add(this.betterProgressBar1);
            this.Controls.Add(this.bpb_joystickXpos);
            this.Controls.Add(this.bpb_joystickXneg);
            this.Controls.Add(this.bpb_joystickYpos);
            this.Controls.Add(this.bpb_joystickYneg);
            this.Controls.Add(this.bpb_trigger);
            this.Controls.Add(this.bpb_gear);
            this.Controls.Add(this.bpb_rudderReset);
            this.Controls.Add(this.bpb_rudderL);
            this.Controls.Add(this.bpb_rudderR);
            this.Controls.Add(this.bpb_throttle);
            this.Controls.Add(this.label6);
            this.Name = "SlideJoystick";
            this.Size = new System.Drawing.Size(1600, 1080);
            this.ResumeLayout(false);

        }

        #endregion
        private BetterProgressBar bpb_airbrake;
        private BetterProgressBar bpb_trigger;
        private BetterProgressBar bpb_gear;
        private BetterProgressBar bpb_rudderReset;
        private BetterProgressBar bpb_rudderL;
        private BetterProgressBar bpb_rudderR;
        private BetterProgressBar bpb_throttle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private BetterProgressBar bpb_joystickTorque;
        private BetterProgressBar betterProgressBar1;
        private BetterProgressBar bpb_joystickXpos;
        private BetterProgressBar bpb_joystickXneg;
        private BetterProgressBar bpb_joystickYpos;
        private BetterProgressBar bpb_joystickYneg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private BetterProgressBar bpb_landingLights;
        private System.Windows.Forms.Label label12;
        private BetterProgressBar bpb_positionLights;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
