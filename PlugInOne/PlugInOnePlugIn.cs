using Rhino;

namespace PlugInOne
{
  /// <summary>
  /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
  /// class. DO NOT create instances of this class yourself. It is the
  /// responsibility of Rhino to create an instance of this class.</para>
  /// <para>To complete plug-in information, please also see all PlugInDescription
  /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
  /// "Show All Files" to see it in the "Solution Explorer" window).</para>
  /// </summary>
  public class PlugInOnePlugIn : Rhino.PlugIns.PlugIn
  {
    public PlugInOnePlugIn()
    {
      Instance = this;
    }

    /// <summary>
    /// Gets the only instance of the PlugInOnePlugIn plug-in.
    /// </summary>
    public static PlugInOnePlugIn Instance
    {
      get;
      private set;
    }

    /// <summary>
    /// Called when the plug-in is loaded
    /// </summary>
    protected override Rhino.PlugIns.LoadReturnCode OnLoad(ref string errorMessage)
    {
      CommonCode.MainController.PrintPlugInName += MainControllerPrintPlugInName;
      CommonCode.MainController.RegisterComputeIntValue(ComputeIntValue);
      return base.OnLoad(ref errorMessage);
    }

    private int ComputeIntValue()
    {
      return PlugInOneCommand.Instance.Integer;
    }

    void MainControllerPrintPlugInName(object sender, System.EventArgs e)
    {
      RhinoApp.WriteLine(Name);
    }

    // You can override methods here to change the plug-in behavior on
    // loading and shut down, add options pages to the Rhino _Option command
    // and mantain plug-in wide options in a document.
  }
}