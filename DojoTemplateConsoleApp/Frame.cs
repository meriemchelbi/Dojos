﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Frame
    {
        public int Roll1 { get; set; }
        public int Roll2 { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }

        //public int FrameScore
        //{
        //    get { return GetFrameScore(); }

        //    private set { }
        //}

        //private int GetFrameScore()
        //{
        //    int frameScore = Roll1 + Roll2;
        //    return frameScore;
        //}
        
    }
}
