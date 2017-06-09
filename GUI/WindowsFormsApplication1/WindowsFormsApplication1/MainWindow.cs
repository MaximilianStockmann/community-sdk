﻿using Emotiv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Namespace
{
    public partial class MainWindow : Form
    {
        // Creating SDK-Instance
        static EmoEngine engine = EmoEngine.Instance;

        // TCP-Connection to Pi
        static TcpClient client;
        static NetworkStream clientStream;
        static Int32 port = 13337;

        // driving related information
        static EdkDll.IEE_MentalCommandAction_t currentAction;
        static bool drivingAllowed = false;  //always check, before sending a command
        static String currentCommand;

        //static bool drivingAllowed = false;

        // Cloud-Profile related information
        static int userCloudID = 0;
        static string userName = "";
        static string password = "";
        static string profileName = "Stefan Doing Stuff";
        static int version = -1; // Lastest version
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // setting mentalCommandActive actions for user
            ulong action1 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_LEFT;
            ulong action2 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_RIGHT;
            ulong action3 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_PUSH;
            ulong action4 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_PULL;
            ulong listAction = action1 | action2 | action3 | action4;
            EmoEngine.Instance.MentalCommandSetActiveActions(0, listAction);

            //passing event handlers to the engine
            engine.EmoEngineConnected += 
                new EmoEngine.EmoEngineConnectedEventHandler(engine_EmoEngineConnected);
            engine.EmoEngineDisconnected += 
                new EmoEngine.EmoEngineDisconnectedEventHandler(engine_EmoEngineDisconnected);
            engine.MentalCommandTrainingStarted += 
                new EmoEngine.MentalCommandTrainingStartedEventEventHandler(engine_MentalCommandTrainingStartedEvent);
            engine.MentalCommandTrainingSucceeded += 
                new EmoEngine.MentalCommandTrainingSucceededEventHandler(engine_MentalCommandTrainingSucceeded);
            engine.MentalCommandTrainingFailed += 
                new EmoEngine.MentalCommandTrainingFailedEventHandler(engine_MentalCommandTrainingFailed);
            engine.MentalCommandTrainingCompleted += 
                new EmoEngine.MentalCommandTrainingCompletedEventHandler(engine_MentalCommandTrainingCompleted);
            engine.MentalCommandEmoStateUpdated += 
                new EmoEngine.MentalCommandEmoStateUpdatedEventHandler(engine_MentalCommandEmoStateUpdated);
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            loadProfileButton.Text = "Hallo";
            
        }

        private void driveButton_Click(object sender, EventArgs e)
        {
            ctBotStatusLabel.Text = "Test";
            if (driveButton.Text == "Start Driving")
            {
                driveButton.Text = "Stop Driving";
                drivingAllowed = true;
                try
                {
                    // Initalisierung
                    client = new TcpClient("192.168.178.33", port);
                    clientStream = client.GetStream();


                    sendCommand("stop");



                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("ArgumentNullException: {0}", ex);
                    ctBotStatusLabel.Text = "ArgumentNullException";
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("SocketException: {0}", ex);
                    ctBotStatusLabel.Text = "SocketException";
                }
            }
            else
            {
                driveButton.Text = "Start Driving";
                drivingAllowed = false;
                if (clientStream == null) return;
                // Close everything.
                clientStream.Close();
                client.Close();
            }

        }

        private void getStatusResponse()
        {

            // Buffer to store the response bytes.
            Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = clientStream.Read(data, 0, data.Length);
            ctBotStatusLabel.Text = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

        }

        private void sendCommand(String cmd)    //Eingaben: "forward", "backward", "left", "right", "stop"
        {

            if (clientStream == null)
            {
                ctBotStatusLabel.Text = "No Server to connect";
                return;
            }

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(cmd);

            clientStream.Write(data, 0, data.Length);

            getStatusResponse();
        }

        static void save()
        {
            int getNumberProfile = EmotivCloudClient.EC_GetAllProfileName(userCloudID);

            int profileID = -1;
            EmotivCloudClient.EC_GetProfileId(userCloudID, profileName, ref profileID);

            if (profileID >= 0)
            {
                // Profile with +profileName+ exists already, updating...
                if (EmotivCloudClient.EC_UpdateUserProfile(userCloudID, 0, profileID) == EdkDll.EDK_OK)
                    ;// Update finished
                else
                    ;// Update failed
            }
            else
            {
                // Saving...

                if (EmotivCloudClient.EC_SaveUserProfile(userCloudID, (int)0, profileName,
                EmotivCloudClient.profileFileType.TRAINING) == EdkDll.EDK_OK)
                    ;// Saving finished
                else
                    ;// Saving failed
            }

            return;
        }

        static void load()
        {
            int getNumberProfile = EmotivCloudClient.EC_GetAllProfileName(userCloudID);

            if (getNumberProfile > 0)
            {
                // Loading...

                int profileID = -1;
                EmotivCloudClient.EC_GetProfileId(userCloudID, profileName, ref profileID);

                if (EmotivCloudClient.EC_LoadUserProfile(userCloudID, 0, profileID, version) == EdkDll.EDK_OK)
                    ;// Loading finished
                else
                    ;// Loading failed
            }
            return;
        }

        //event handlers for the engine
        public void engine_EmoEngineConnected(object sender, EmoEngineEventArgs e)
        {
            //todo...
        }

        public void engine_EmoEngineDisconnected(object sender, EmoEngineEventArgs e)
        {
            //todo...
        }

        public void engine_MentalCommandTrainingStartedEvent(object sender, EmoEngineEventArgs e)
        {
            //todo...
        }

        public void engine_MentalCommandTrainingSucceeded(object sender, EmoEngineEventArgs e)
        {
            //todo...
        }

        public void engine_MentalCommandTrainingFailed(object sender, EmoEngineEventArgs e)
        {
            ctBotStatusLabel.Text = "Training failed!";
        }

        public void engine_MentalCommandTrainingCompleted(object sender, EmoEngineEventArgs e)
        {
            //todo...
        }

        public void engine_MentalCommandEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;
            currentAction = es.MentalCommandGetCurrentAction();
            currentCommand = currentActionToString();
            if (drivingAllowed)
            {
                sendCommand(currentCommand);
            }
        }

        //returns the command to send to the bot
        private String currentActionToString()
        {
            switch(currentAction)
            {
                case EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL: return "stop";
                case EdkDll.IEE_MentalCommandAction_t.MC_LEFT: return "left";
                case EdkDll.IEE_MentalCommandAction_t.MC_RIGHT: return "right";
                case EdkDll.IEE_MentalCommandAction_t.MC_PUSH: return "forward";
                case EdkDll.IEE_MentalCommandAction_t.MC_PULL: return "backward";
                default: return ""; // there is no active command (this should never happen (neutral is a command), so we don't handle it)
            }
        }

        private void resetProfileButton_Click(object sender, EventArgs e)
        {
            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL);
            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ERASE);
            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_PUSH);
            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ERASE);
            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_PULL);
            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ERASE);
            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_LEFT);
            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ERASE);
            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_RIGHT);
            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_ERASE);
        }

        private void trainActionButton_Click(object sender, EventArgs e)
        {             
            switch (trainActionSelectionComboBox.Text)
            {
                case "Stop":
                    EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL);
                    EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
                    break;
                case "Forward":
                    EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_PUSH);
                    EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
                    break;
                case "backward":
                    EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_PULL);
                    EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
                    break;
                case "Left":
                    EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_LEFT);
                    EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
                    break;
                case "Right":
                    EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_RIGHT);
                    EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
                    break;
                default:
                    break;
            }
        }
    }
}
