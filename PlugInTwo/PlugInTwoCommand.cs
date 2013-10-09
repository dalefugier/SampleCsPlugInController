using Rhino;
using Rhino.Commands;

namespace PlugInTwo
{
  [System.Runtime.InteropServices.Guid("3143f020-6702-4d6b-a452-ee914b91851e")]
  public class PlugInTwoCommand : Command
  {
    public int Integer { get; set; }

    public PlugInTwoCommand()
    {
      // Rhino only creates one instance of each command class defined in a
      // plug-in, so it is safe to store a refence in a static property.
      Instance = this;
      Integer = 0;
    }

    /// <summary>
    /// The only instance of this command.
    /// </summary>
    public static PlugInTwoCommand Instance
    {
      get;
      private set;
    }

    /// <returns>
    /// The command name as it appears on the Rhino command line.
    /// </returns>
    public override string EnglishName
    {
      get { return "PlugInTwoCommand"; }
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
