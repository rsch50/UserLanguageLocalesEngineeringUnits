#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.NetLogic;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.OPCUAServer;
using System.Diagnostics;
#endregion

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void Method1()
    {
        // UserLanguageLocalesEngineeringUnits/Model/Object1
        // get data stored in optix
        var myData = Project.Current.Get("Model/Object1");
        // var test = Session.Get()
        // var myData = Session.Get("Model/Object1");       

        Debug.Assert(myData != null);

        int i = 0;

        foreach (FTOptix.Core.AnalogItem item in myData.Children)
        {
            var newLabel = InformationModel.Make<Label>(NodeId.Random(1).ToString().Replace("1/", ""));
            LocalizedText textID = new LocalizedText(item.EngineeringUnits.NamespaceIndex, item.EngineeringUnits.DisplayName.TextId);
            string neueVariable = InformationModel.LookupTranslation(textID).Text;
            newLabel.Text = i++.ToString() + "  " + item.BrowseName + " --> " + item.Value + " [" + neueVariable + "]";

            IUANode node = LogicObject.GetAlias("Alias1");
            node.Add(newLabel);
        }
    }
}
