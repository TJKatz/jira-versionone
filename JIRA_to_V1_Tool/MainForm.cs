using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace JIRA_to_V1_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label_fileSelected.Text = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('\\') + 1);
            button_convert.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Start new excel application
            Excel.Application excelApp = new Excel.Application();
            
            //Open JIRA output as 'jiraBook'
            Excel.Workbook jiraBook = excelApp.Workbooks.Open(openFileDialog1.FileName);
            
            //Set sheets of jiraBook as 'jiraSheetSet'
            Excel.Sheets jiraSheetSet = jiraBook.Worksheets;

            //Set default number of sheets in new workbook to 7
            //excelApp.SheetsInNewWorkbook = 7;

            //Create new workbook 'v1Book' and save as chosen file dir/name            
            //Excel.Workbook v1Book = excelApp.Workbooks.Add(Environment.CurrentDirectory + "\\Advanced_Backlog_Import_Template.xls");
            Excel.Workbook v1Book = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Advanced_Backlog_Import_Template.xls");
            v1Book.SaveAs(saveFileDialog1.FileName);

            //Set sheets of v1Book as 'v1SheetsSet'
            Excel.Sheets v1SheetSet = v1Book.Worksheets;
            Excel.Worksheet jiraSheet;
            
            //Rename sheets for template
            
            //Excel.Worksheet epicSheet;
            Excel.Worksheet storySheet;
            Excel.Worksheet taskSheet;
            //Excel.Worksheet testSheet;
            //Excel.Worksheet defectSheet;
            //Excel.Worksheet requestSheet;
            //Excel.Worksheet issueSheet;
            
            
            
            //epicSheet = (Excel.Worksheet)v1SheetSet.get_Item(1);
            //epicSheet.Name = "1 - Epics";
            storySheet = (Excel.Worksheet)v1SheetSet.get_Item(2);
            //storySheet.Name = "2 - Stories";
            taskSheet = (Excel.Worksheet)v1SheetSet.get_Item(3);
            //taskSheet.Name = "3 - Tasks";
            //testSheet = (Excel.Worksheet)v1SheetSet.get_Item(4);
            //testSheet.Name = "4 - Tests";
            //defectSheet = (Excel.Worksheet)v1SheetSet.get_Item(5);
            //defectSheet.Name = "5 - Defects";
            //requestSheet = (Excel.Worksheet)v1SheetSet.get_Item(6);
            //requestSheet.Name = "6 - Requests";
            //issueSheet = (Excel.Worksheet)v1SheetSet.get_Item(7);
            //issueSheet.Name = "7 - Issues";
            


            jiraSheet = jiraSheetSet.get_Item(1);
            
            //Create column headers to complete v1 import template
            String[] epicColumnHeaders = {"AssetType", "Name", "Scope", "Description", "Swag", "Reference", "Status", "Priority", "Risk", "Source", "Category", "Owner", "Super"};
            String[] storyColumnHeaders = {"AssetType", "Name", "Scope", "Description",	"Estimate",	"OriginalEstimate",	"Reference", "RequestedBy",	"LastVersion", "Timebox", "Customer", "Status", "Priority", "Risk", "Source", "Category", "Parent", "Team",	"Owners", "Super"};
            String[] taskColumnHeaders = {"AssetType", "Name", "Parent", "Description", "DetailEstimate", "ToDo", "Reference", "LastVersion", "Status", "Source", "Category", "Owners"};
            String[] testColumnHeaders = {"AssetType", "Name", "Parent", "Description", "DetailEstimate", "ToDo", "Reference", "Setup", "Inputs", "Steps", "ExpectedResults", "ActualResults", "VersionTested", "Category", "Status", "Owners"};
            String[] defectColumnHeaders = {"AssetType", "Name", "Scope", "Description", "Estimate", "DetailEstimate", "Reference", "Environment", "FoundBy", "FoundInBuild", "FixedInBuild", "VerifiedBy", "VersionAffected", "Timebox", "ToDo", "Status", "Priority", "ResolutionReason", "Resolution", "Source", "Type", "Parent", "Team", "Owners"};
            String[] requestColumnHeaders = { "AssetType", "Name", "Scope", "Description", "Owner", "Category", "Priority", "Reference", "RequestedBy", "ResolutionReason", "Resolution", "Source", "Status"};
            String[] issueColumnHeaders = {"AssetType", "Name", "Scope", "Description",	"Team", "Owner", "Category", "IdentifiedBy", "Priority", "Reference", "ResolutionReason", "Resolution", "Source", "TargetDate"};
            Object[] columnHeaderArrays = { epicColumnHeaders, storyColumnHeaders, taskColumnHeaders, testColumnHeaders, defectColumnHeaders, requestColumnHeaders, issueColumnHeaders };
            ArrayList columnHeaderArrayList = new ArrayList(columnHeaderArrays);

            String assetType;
            String numberOfIssues = jiraSheet.get_Range("A3").Value2;
            int totalAssets = Int32.Parse(numberOfIssues.Substring(11,2));

            //Copy range to object array 'jiraData' for data manipulation
            Object[,] jiraData;
            jiraData = jiraSheet.get_Range("A4", "FT" + (4 + totalAssets).ToString()).Value2;
            
            //Mapping algorithm
            Object[,] v1EpicData = new Object[totalAssets + 1, 13];
            Object[,] v1StoryData = new Object[totalAssets + 1, 20];
            Object[,] v1TaskData = new Object[totalAssets + 1, 12];
            Object[,] v1TestData = new Object[totalAssets + 1, 16];
            Object[,] v1DefectData = new Object[totalAssets + 1, 24];
            Object[,] v1RequestData = new Object[totalAssets + 1, 13];
            Object[,] v1IssueData = new Object[totalAssets + 1, 14];
            int[] v1DataArrayLengths = { v1EpicData.Length, v1StoryData.Length, v1TaskData.Length, v1TestData.Length, v1DefectData.Length, v1RequestData.Length, v1IssueData.Length};

            /*Copying column headers for all sheets to v1 arrays
            for (int i = 0; i < v1DataArrayLengths.Max(); i++)
            {
                if (i < epicColumnHeaders.Length)
                    v1EpicData[0, i] = epicColumnHeaders[i];
                if (i < storyColumnHeaders.Length)
                    v1StoryData[0, i] = storyColumnHeaders[i];
                if (i < taskColumnHeaders.Length)
                    v1TaskData[0, i] = taskColumnHeaders[i];
                if (i < testColumnHeaders.Length)
                    v1TestData[0, i] = testColumnHeaders[i];
                if (i < defectColumnHeaders.Length)
                    v1DefectData[0, i] = defectColumnHeaders[i];
                if (i < requestColumnHeaders.Length)
                    v1RequestData[0, i] = requestColumnHeaders[i];
                if (i < issueColumnHeaders.Length)
                    v1IssueData[0, i] = issueColumnHeaders[i];
            }
            */
            
            //for loop iterates through JIRA rows looking for User Stories first
            int currentTaskRow = 0;
            int currentStoryRow = 0;
            Dictionary<String, String> parentKeyMap = new Dictionary<String, String>(0);
            
            for(int jiraRow = 1; jiraRow < totalAssets + 2; jiraRow++){
                assetType = (String)jiraData[jiraRow, 4];
                if (assetType == "User Story")
                {
                    //Create story name (sub-task 'parent')
                    String storyName = (String)jiraData[jiraRow, 2] + " " + (String)jiraData[jiraRow, 3];
                    v1StoryData[currentStoryRow, 1] = storyName;
                    String[] subTaskKeys;

                    //Find sub-tasks if any and add to dictionary (JIRA Sub-task key, storyName)
                    if (jiraData[jiraRow, 24] != null)
                    {
                        
                        subTaskKeys = jiraData[jiraRow, 24].ToString().Split(',');
                        for (int i = 0; i < subTaskKeys.Length; i++)
                        {
                            parentKeyMap.Add(subTaskKeys[i].Trim(), storyName);
                        }
                    }
                    
                    v1StoryData[currentStoryRow, 0] = "Story";
                    v1StoryData[currentStoryRow, 2] = (String)jiraData[jiraRow, 1];

                    String tempCOA = jiraData[jiraRow, 121] != null ? jiraData[jiraRow, 121].ToString() : "";
                    String tempNotes = jiraData[jiraRow, 106] != null ? jiraData[jiraRow, 106].ToString() : "";

                    v1StoryData[currentStoryRow, 3] = tempCOA + "\n\nNOTES: " + tempNotes;
                    v1StoryData[currentStoryRow, 4] = jiraData[jiraRow, 148];
                    v1StoryData[currentStoryRow, 5] = jiraData[jiraRow, 20] != null ? (Double.Parse(jiraData[jiraRow, 20].ToString())/3600).ToString() : "0";
                    //v1StoryData[currentStoryRow, 9] = (String)jiraData[jiraRow, 132];
                    
                    /*Customer field (currently left blank)
                    v1StoryData[currentStoryRow, 10] = (String)jiraData[jiraRow, 9];
                    */
                        //Status conversion
                        String jiraStatus = (String)jiraData[jiraRow, 5];
                        String v1Status;
                        
                        switch (jiraStatus)
                        {
                            case "Open":
                                v1Status = "Ready";
                                break;
                            case "Closed":
                                v1Status = "Done";
                                break;
                            default:
                                v1Status = "In Progress";
                                break;
                        }
                        v1StoryData[currentStoryRow, 11] = v1Status;
                        
                        //Priority conversion
                        //String jiraPriority = (String)jiraData[jiraRow, 6];
                        String v1Priority = "Medium";
                        
                        /*
                        switch (jiraPriority)
                        {
                            case "Low (Low)":
                                v1Priority = "Low";
                                break;
                            case "Minor (Medium)":
                                v1Priority = "Medium";
                                break;
                            case "High (High)":
                                v1Priority = "High";
                                break;
                            default:
                                v1Priority = "Medium";
                                break;
                        }
                        */
                        
                        //
                        v1StoryData[currentStoryRow, 12] = v1Priority;
                        //v1StoryData[currentStoryRow, 18] = jiraData[jiraRow, 8];
                        currentStoryRow++;

                }
            }
            
            //Iterate through JIRA rows looking for sub-tasks
            for(int jiraRow = 1; jiraRow < totalAssets + 2; jiraRow++){
                assetType = (String)jiraData[jiraRow, 4];
                if (assetType == "Sub-task"){
                    v1TaskData[currentTaskRow, 0] = "Task";
                    v1TaskData[currentTaskRow, 1] = (String)jiraData[jiraRow, 2] + ": " + (String)jiraData[jiraRow, 3];
                    v1TaskData[currentTaskRow, 2] = parentKeyMap[jiraData[jiraRow, 2].ToString()];

                    String tempTimeSpent = jiraData[jiraRow, 22] != null ? (Double.Parse(jiraData[jiraRow, 22].ToString()) / 3600).ToString() : "0";
                    String tempNotes = jiraData[jiraRow, 106] != null ? jiraData[jiraRow, 106].ToString() : "None";
                    
                    v1TaskData[currentTaskRow, 3] = "Time Spent: " + tempTimeSpent + "\n\nNotes: " + tempNotes;
                    v1TaskData[currentTaskRow, 4] = jiraData[jiraRow, 20] != null ? (Double.Parse(jiraData[jiraRow, 20].ToString()) / 3600).ToString() : "0";
                    v1TaskData[currentTaskRow, 5] = jiraData[jiraRow, 21] != null ? (Double.Parse(jiraData[jiraRow, 21].ToString()) / 3600).ToString() : "0";

                    //Status conversion
                    String jiraStatus = (String)jiraData[jiraRow, 5];
                    String v1Status;

                    switch (jiraStatus)
                    {
                        case "Open":
                            v1Status = "Ready";
                            break;
                        case "Closed":
                            v1Status = "Done";
                            break;
                        default:
                            v1Status = "In Progress";
                            break;
                    }

                    //v1TaskData[currentTaskRow, 8] = v1Status;
                    currentTaskRow++;
                }
            }
            





            //Object[,] v1Data = jiraData;

            //Write to v1book (taskSheet & storySheet) and formatting
            //epicSheet.get_Range("A1", "M1").Value2 = v1EpicData;
            storySheet.get_Range("A2", "T" + (currentStoryRow + 1).ToString()).Value2 = v1StoryData;
            taskSheet.get_Range("A2", "L" + (currentTaskRow + 1).ToString()).Value2 = v1TaskData;
            //testSheet.get_Range("A1", "P1").Value2 = v1TestData;
            //defectSheet.get_Range("A1", "X1").Value2 = v1DefectData;
            //requestSheet.get_Range("A1", "M1").Value2 = v1RequestData;
            //issueSheet.get_Range("A1", "N1").Value2 = v1IssueData;
            
            storySheet.get_Range("A1", "T" + (currentStoryRow + 1).ToString()).ColumnWidth = 33;
            storySheet.get_Range("A1", "T" + (currentStoryRow + 1).ToString()).RowHeight = 30;
            taskSheet.get_Range("A1", "L" + (currentTaskRow + 1).ToString()).ColumnWidth = 33;
            taskSheet.get_Range("A1", "L" + (currentTaskRow + 1).ToString()).RowHeight = 30;

            //Save and close
            v1Book.Save();
            excelApp.Application.Workbooks.Close();

            //Notification
            System.Windows.Forms.MessageBox.Show("Successful Launch!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
