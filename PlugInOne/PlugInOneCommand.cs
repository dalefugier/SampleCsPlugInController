using Rhino;
using Rhino.Commands;

namespace PlugInOne
{
  [System.Runtime.InteropServices.Guid("cf94ff1b-c168-4ab2-855a-e69a5cc47bb8")]
  public class PlugInOneCommand : Command
  {
    public int Integer { get; set; }

    public PlugInOneCommand()
    {
      // Rhino only creates one instance of each command class defined in a
      // plug-in, so it is safe to store a refence in a static property.
      Instance = this;
      Integer = 0;
    }

    /// <summary>
    /// The only instance of this command.
    /// </summary>
    public static PlugInOneCommand Instance
    {
      get;
      private set;
    }

    /// <returns>
    /// The command name as it appears on the Rhino command line.
    /// </returns>
    public override string EnglishName
    {
      get { return "PlugInOneCommand"; }
    }

    /// <summary>
    /// Called by Rhino to run your command.
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      int value = Integer;
      Result rc = Rhino.Input.RhinoGet.GetInteger("New integer value", true, ref value);
      if (rc == Result.Success)
        Integer = value;
      return rc;
    }
  }
}
