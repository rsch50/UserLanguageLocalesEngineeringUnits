#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using System.ComponentModel.DataAnnotations;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void Method1()
    {
        // get data stored in optix
        var myData = Project.Current.Get("Model/Object1");
        int i = 0;

        foreach (FTOptix.Core.AnalogItem item in myData.Children)
        {

            var newLabel = InformationModel.Make<Label>(NodeId.Random(1).ToString().Replace("1/", ""));
            newLabel.Text = i++.ToString()+ "  " + item.BrowseName + " --> " + item.Value + " [" + item.EngineeringUnits.DisplayName.Text + "]";

            IUANode node = Project.Current.Get("UI/MainWindow/Screen1/Rectangle1/Panel1/Rectangle1/ScrollView1/VerticalLayout1");
            node.Add(newLabel);
        }
    }
}
