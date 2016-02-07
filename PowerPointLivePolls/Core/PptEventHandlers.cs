using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPT = Microsoft.Office.Interop.PowerPoint;

namespace PowerPointLivePolls.Core
{
    public class PptEventHandlers : IDisposable
    {
        PPT.Application _app;
        public PptEventHandlers(PPT.Application pptApp)
        {
            _app = pptApp;
            
            _app.SlideShowBegin += new PPT.EApplication_SlideShowBeginEventHandler(_app_SlideShowBegin);
            _app.SlideShowEnd += new PPT.EApplication_SlideShowEndEventHandler(_app_SlideShowEnd);
            _app.SlideShowNextSlide += new PPT.EApplication_SlideShowNextSlideEventHandler(_app_SlideShowNextSlide);            
        }

        void _app_SlideShowNextSlide(PPT.SlideShowWindow Wn)
        {
            System.Windows.Forms.MessageBox.Show("Next slide");
        }

        void _app_SlideShowEnd(PPT.Presentation Pres)
        {
            System.Windows.Forms.MessageBox.Show("Slide show end");
        }

        void _app_SlideShowBegin(PPT.SlideShowWindow Wn)
        {
            System.Windows.Forms.MessageBox.Show("Slide show beging");
        }

        public void Disposing(bool disposing)
        {
            if (_app == null || !disposing) return;

            _app.SlideShowBegin -= new PPT.EApplication_SlideShowBeginEventHandler(_app_SlideShowBegin);
            _app.SlideShowEnd -= new PPT.EApplication_SlideShowEndEventHandler(_app_SlideShowEnd);
            _app.SlideShowNextSlide -= new PPT.EApplication_SlideShowNextSlideEventHandler(_app_SlideShowNextSlide);            
        }

        public void Dispose()
        {
            Disposing(true);
        }
    }
}
