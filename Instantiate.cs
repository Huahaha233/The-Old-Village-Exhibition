using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ins
{
    //传入展示的分类（家具，建筑，视频，图片类）
    //传入点击序号（点击了拿一张图片）
    //根据两张图片，将物体实例化
    interface IInstantiate
    {
        
    }
    class Instantiate : IInstantiate
    {
        private string sort = null;//类别
        private int clicknum = 0;//按钮序号

    }
}
