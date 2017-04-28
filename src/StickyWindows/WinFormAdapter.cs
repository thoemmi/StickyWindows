////////////////////////////////////////////////////////////////////////////////
// StickyWindows
// 
// Copyright (c) 2009 Riccardo Pietrucci
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the author be held liable for any damages arising from 
// the use of this software.
// Permission to use, copy, modify, distribute and sell this software for any 
// purpose is hereby granted without fee, provided that the above copyright 
// notice appear in all copies and that both that copyright notice and this 
// permission notice appear in supporting documentation.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickyWindows {
    public class WinFormAdapter : BaseFormAdapter {
        private readonly Form _form;

        public WinFormAdapter(Form form) {
            _form = form;
        }

        public override IntPtr Handle => _form.Handle;

        protected override Rectangle InternalBounds {
            get { return _form.Bounds; }
            set { _form.Bounds = value; }
        }

        public override Size MaximumSize {
            get { return _form.MaximumSize; }
            set { _form.MaximumSize = value; }
        }

        public override Size MinimumSize {
            get { return _form.MinimumSize; }
            set { _form.MinimumSize = value; }
        }

        public override bool Capture {
            get { return _form.Capture; }
            set { _form.Capture = value; }
        }

        public override void Activate() {
            _form.Activate();
        }

        public override Point PointToScreen(Point point) {
            return _form.PointToScreen(point);
        }
    }
}