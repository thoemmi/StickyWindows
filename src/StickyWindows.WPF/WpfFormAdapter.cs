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
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace StickyWindows.WPF {
    public class WpfFormAdapter : BaseFormAdapter {
        private readonly Window _window;
        private Point? _origin;

        public WpfFormAdapter(Window window) {
            _window = window;
        }

        public override IntPtr Handle => new WindowInteropHelper(_window).Handle;

        protected override Rectangle InternalBounds {
            get {
                // converti width ed height ad absolute
                var widthHeightPointConverted = FromRelativeToDevice(_window.ActualWidth, _window.ActualHeight, _window);

                // converti coordinate da relative a screen: la libreria lavora con quelle
                var origin = GetWindowOrigin();
                var pStart = PointToScreen(origin);
                var pEnd = PointToScreen(origin + new Size(Convert.ToInt32(widthHeightPointConverted.X), Convert.ToInt32(widthHeightPointConverted.Y)));
                pEnd.Offset(-pStart.X, -pStart.Y); // ora pend rappresenta width + height

                // imposta
                return new Rectangle(pStart.X, pStart.Y, pEnd.X, pEnd.Y);
            }
            set {
                // converti width ed height a relative
                var widthHeightPointConverted = FromDeviceToRelative(value.Width, value.Height, _window);
                // converti coordinate da screen a relative: il video non si deve alterare!
                var origin = GetWindowOrigin();
                var screenPointRef = new Point(-origin.X + value.X, -origin.Y + value.Y);
                var pStart = PointFromScreen(new Point(screenPointRef.X, screenPointRef.Y));

                // imposta
                _window.Left += pStart.X;
                _window.Top += pStart.Y;
                _window.Width = widthHeightPointConverted.X;
                _window.Height = widthHeightPointConverted.Y;
            }
        }

        public override Size MaximumSize {
            get => new Size(Convert.ToInt32(_window.MaxWidth), Convert.ToInt32(_window.MaxHeight));
            set {
                _window.MaxWidth = value.Width;
                _window.MaxHeight = value.Height;
            }
        }

        public override Size MinimumSize {
            get => new Size(Convert.ToInt32(_window.MinWidth), Convert.ToInt32(_window.MinHeight));
            set {
                _window.MinWidth = value.Width;
                _window.MinHeight = value.Height;
            }
        }

        public override bool Capture {
            get => _window.IsMouseCaptured;
            set {
                IInputElement targetToCapture = value ? _window : null;
                Mouse.Capture(targetToCapture);
            }
        }

        public override void Activate() {
            _window.Activate();
        }

        public override Point PointToScreen(Point pointWin) {
            var p = new System.Windows.Point();
            var resultWpf = ToWinPoint(_window.PointToScreen(p));
            var resultScaled = resultWpf + new Size(pointWin);
            return resultScaled;
        }

        private Point GetWindowOrigin() {
            // TODO: alla prima invocazione far andare in cache per migliorare perf ed evitare errori di approx
            //return new Point(-4, -28);
            if (!_origin.HasValue) {
                var currentWinPointConverted = FromRelativeToDevice(-_window.Left, -_window.Top, _window);
                var locationFromScreen = PointToScreen(ToWinPoint(currentWinPointConverted));
                _origin = new Point(-locationFromScreen.X, -locationFromScreen.Y);
            }

            return _origin.Value;
        }

        private static System.Windows.Point FromDeviceToRelative(double x, double y, Visual workingVisual) {
            var widthHeightPoint = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            var source = PresentationSource.FromVisual(workingVisual);
            return source.CompositionTarget.TransformFromDevice.Transform(ToWpfPoint(widthHeightPoint));
        }

        private static System.Windows.Point FromRelativeToDevice(double x, double y, Visual workingVisual) {
            var widthHeightPoint = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            var source = PresentationSource.FromVisual(workingVisual);
            return source.CompositionTarget.TransformToDevice.Transform(ToWpfPoint(widthHeightPoint));
        }

        private Point PointFromScreen(Point pointWin) {
            return ToWinPoint(_window.PointFromScreen(ToWpfPoint(pointWin)));
        }

        private static System.Windows.Point ToWpfPoint(Point point) {
            return new System.Windows.Point(point.X, point.Y);
        }

        private static Point ToWinPoint(System.Windows.Point point) {
            return new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y));
        }
    }
}