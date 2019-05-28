//
// NativeWindowSettings.cs
//
// Copyright (C) 2019 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using System;
using OpenToolkit.GraphicsLibraryFramework;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.Common.Input;
using Monitor = OpenToolkit.Windowing.Common.Monitor;

namespace OpenToolkit.Windowing.Desktop
{
    /// <summary>
    /// Implementation of <see cref="INativeWindowProperties"/>.
    /// <see cref="NativeWindow"/> related settings.
    /// </summary>
    public class NativeWindowSettings : INativeWindowProperties
    {
        /// <summary>
        /// Gets the default settings for a <see cref="NativeWindow"/>.
        /// </summary>
        public static readonly NativeWindowSettings Default = new NativeWindowSettings();

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeWindowSettings"/> class.
        /// </summary>
        public NativeWindowSettings()
        {
            IsEventDriven = false;

            unsafe
            {
                CurrentMonitor = new Monitor((IntPtr)GLFWProvider.GLFW.Value.GetPrimaryMonitor());
            }

            Title = "OpenTK Window";
            IsFocused = true;
            IsVisible = true;

            WindowState = WindowState.Normal;
            WindowBorder = WindowBorder.Resizable;

            X = GLFW.DontCare;
            Y = GLFW.DontCare;

            Width = 640;
            Height = 360;

            IsFullscreen = false;

            Exists = true;
        }

        /// <inheritdoc />
        public WindowIcon Icon { get; set; }

        /// <inheritdoc />
        public bool IsEventDriven { get; set; }

        /// <inheritdoc />
        public string ClipboardString { get; set; }

        /// <inheritdoc />
        public Monitor CurrentMonitor { get; set; }

        /// <inheritdoc />
        public string Title { get; set; }

        /// <inheritdoc />
        public bool IsFocused { get; set; }

        /// <inheritdoc />
        public bool IsVisible { get; set; }

        /// <inheritdoc />
        public bool Exists { get; }

        /// <inheritdoc />
        public WindowState WindowState { get; set; }

        /// <inheritdoc />
        public WindowBorder WindowBorder { get; set; }

        /// <inheritdoc />
        public Box2 Bounds
        {
            get => Box2.FromDimensions(Location, Size);
            set
            {
                _location = new Vector2(value.Left, value.Left);
                _size = new Vector2(value.Width, value.Height);
            }
        }

        private Vector2i _location;

        /// <inheritdoc />
        public Vector2i Location
        {
            get => _location;
            set => _location = value;
        }

        private Vector2i _size;

        /// <inheritdoc />
        public Vector2i Size
        {
            get => _size;
            set => _size = value;
        }

        /// <inheritdoc />
        public int X
        {
            get => Location.X;
            set => _location.X = value;
        }

        /// <inheritdoc />
        public int Y
        {
            get => Location.Y;
            set => _location.Y = value;
        }

        /// <inheritdoc />
        public int Width
        {
            get => Size.X;
            set => _size.X = value;
        }

        /// <inheritdoc />
        public int Height
        {
            get => Size.Y;
            set => _size.Y = value;
        }

        /// <inheritdoc />
        public Box2 ClientRectangle
        {
            get => Box2.FromDimensions(Location, Size);

            set
            {
                Location = new Vector2i(value.Right, value.Top);
                Size = new Vector2i(value.Width, value.Height);
            }
        }

        /// <inheritdoc />
        public Vector2 ClientSize { get; }

        /// <inheritdoc />
        public bool IsFullscreen { get; set; }
    }
}
