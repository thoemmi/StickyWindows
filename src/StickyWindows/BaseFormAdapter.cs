////////////////////////////////////////////////////////////////////////////////
// StickyWindows
//
// Copyright (c) 2009 Riccardo Pietrucci, 2017 Thomas Freudenberg
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
using System.Runtime.InteropServices;

namespace StickyWindows {
    public abstract class BaseFormAdapter {
        private bool _isExtendedFrameMarginInitialized;
        private Rectangle _extendedFrameMargin;

        public abstract IntPtr Handle { get; }
        protected abstract Rectangle InternalBounds { get; set; }
        public abstract Size MaximumSize { get; set; }
        public abstract Size MinimumSize { get; set; }
        public abstract bool Capture { get; set; }
        public abstract void Activate();
        public abstract Point PointToScreen(Point point);

        private void InitExtendedFrameMargin() {
            if (_isExtendedFrameMarginInitialized) {
                return;
            }

            Win32.RECT rect;
            if (Win32.DwmGetWindowAttribute(Handle, Win32.DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out rect,
                    Marshal.SizeOf(typeof(Win32.RECT))) == 0)
            {
                var originalFormBounds = InternalBounds;
                _extendedFrameMargin = new Rectangle(
                    -(originalFormBounds.Left - rect.Left),
                    -(originalFormBounds.Top - rect.Top),
                    -(originalFormBounds.Width - (rect.Right - rect.Left)),
                    -(originalFormBounds.Height - (rect.Bottom - rect.Top)));
            }
            else
            {
                _extendedFrameMargin = Rectangle.Empty;
            }
            _isExtendedFrameMarginInitialized = true;
        }

        public Rectangle Bounds {
            get {
                InitExtendedFrameMargin();

                var bounds = InternalBounds;
                bounds.X += _extendedFrameMargin.Left;
                bounds.Y += _extendedFrameMargin.Top;
                bounds.Width += _extendedFrameMargin.Width;
                bounds.Height += _extendedFrameMargin.Height;

                return bounds;
            }
            set {
                InitExtendedFrameMargin();

                var bounds = value;
                bounds.X -= _extendedFrameMargin.Left;
                bounds.Y -= _extendedFrameMargin.Top;
                bounds.Width -= _extendedFrameMargin.Width;
                bounds.Height -= _extendedFrameMargin.Height;
                InternalBounds = bounds;
            }
        }
    }
}