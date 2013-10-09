using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonCode
{
  public static class MainController
  {
    public delegate int ComputeIntValue();

    public static void RegisterComputeIntValue(ComputeIntValue function)
    {
      g_callbacks.Add(function);
    }

    public static int ComputeTotalIntValue()
    {
      var total = 0;
      foreach (var callback in g_callbacks)
        total += callback();
      return total;
    }

    public static int NumberOfRegisteredCallbacks()
    {
      return g_callbacks.Count();
    }

    public static void PrintPlugInNames()
    {
      if (null != PrintPlugInName)
        PrintPlugInName.Invoke(null, EventArgs.Empty);
    }

    public static event EventHandler PrintPlugInName;

    private static readonly List<ComputeIntValue> g_callbacks = new List<ComputeIntValue>();
  }
}
