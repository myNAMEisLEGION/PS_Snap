﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.ParametersPage.HardCore
{
    interface IParametersPage<TM>
        : IPage<TM> where TM : BasePageElementMap, new()
    {
    }
}
