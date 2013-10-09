using Rhino;
using Rhino.Commands;

namespace MainPlugIn
{
  [System.Runtime.InteropServices.Guid("e5d491af-818b-4d36-bbc5-a23ce5abdbbc")]
  public class MainPlugInCommand : Command
  {
    public MainPlugInCommand()
    {
      // Rhino only creates one instance of each command class defined in a
      // plug-in, so it is safe to store a refence in a static property.
      Instance = this;
    }

    ///<summary>The only instance of this command.</summary>
    public static MainPlugInCommand Instance
    {
      get;
      private set;
    }

    ///<returns>The command name as it appears on the Rhino command line.</returns>
    public override string EnglishName
    {
      get { return "MainPlugInCommand"; }
    }

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      var total = CommonCode.MainController.ComputeTotalIntValue();
      RhinoApp.WriteLine("The total count is: " + total);
      RhinoApp.WriteLine("The loaded plug-in's are:");
      CommonCode.MainController.PrintPlugInNames();
      return Result.Success;
    }
  }
}
