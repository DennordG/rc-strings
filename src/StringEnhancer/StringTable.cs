﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caphyon.RcStrings.StringEnhancer
{
  public class StringTable
  {
    #region Members

    private StringLine[] mStringLinesArray = new StringLine[ParseConstants.kMaximumNumberOfStringsInStringTable];

    #endregion

    #region Properties

    public int StringTableNumber { get; private set; }  // string id / 16
    public int RcOrder { get; private set; }
    public int ElementsCount { get; private set; }

    #endregion

    #region Ctor

    public StringTable(int aStringTableNumber, int aRcOrder)
    {
      RcOrder = aRcOrder;
      StringTableNumber = aStringTableNumber;
      ElementsCount = 0;
    }

    #endregion

    #region Public methods

    // id % 16 = position in stringLinesArray 
    public void AddInformation(StringLine aStringLine)
    {
      ElementsCount = ElementsCount + 1;
      mStringLinesArray[aStringLine.Id % ParseConstants.kMaximumNumberOfStringsInStringTable] = aStringLine;
    }

    public bool IsPositionEmpty(int aPosition) => mStringLinesArray[aPosition] == null;

    public void Display(StreamWriter aStreamWriter)
    {
      foreach (var stringLine in mStringLinesArray.Where(item => item != null))
        aStreamWriter.WriteLine(stringLine);
    }

    #endregion
  }
}
