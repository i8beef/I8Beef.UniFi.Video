namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Image settings.
    /// </summary>
    public class IspSettings
    {
        /// <summary>
        /// Brightness.
        /// </summary>
        public int Brightness { get; set; }

        /// <summary>
        /// Contrast.
        /// </summary>
        public int Contrast { get; set; }

        /// <summary>
        /// Denoise.
        /// </summary>
        public int Denoise { get; set; }

        /// <summary>
        /// Hue.
        /// </summary>
        public int Hue { get; set; }

        /// <summary>
        /// Saturation.
        /// </summary>
        public int Saturation { get; set; }

        /// <summary>
        /// Sharpness.
        /// </summary>
        public int Sharpness { get; set; }

        /// <summary>
        /// Flip image.
        /// </summary>
        public bool Flip { get; set; }

        /// <summary>
        /// Mirror image.
        /// </summary>
        public bool Mirror { get; set; }

        /// <summary>
        /// Gamma correction
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public object Gamma { get; set; }

        /// <summary>
        /// WDR.
        /// </summary>
        public bool Wdr { get; set; }

        /// <summary>
        /// AE mode.
        /// </summary>
        public string AeMode { get; set; }

        /// <summary>
        /// IR LED mode.
        /// </summary>
        public IrLedMode IrLedMode { get; set; }

        /// <summary>
        /// IR LED level.
        /// </summary>
        public int IrLedLevel { get; set; }

        /// <summary>
        /// Focus mode.
        /// </summary>
        public string FocusMode { get; set; }

        /// <summary>
        /// Focus position.
        /// </summary>
        public int FocusPosition { get; set; }

        /// <summary>
        /// Zoom position.
        /// </summary>
        public int ZoomPosition { get; set; }

        /// <summary>
        /// ICR sensitivity.
        /// </summary>
        public int IcrSensitivity { get; set; }

        /// <summary>
        /// Aggressive anti flicker.
        /// </summary>
        public int AggressiveAntiFlicker { get; set; }

        /// <summary>
        /// Enable 3DNR.
        /// </summary>
        public int? Enable3Dnr { get; set; }

        /// <summary>
        /// Zoom sream Id.
        /// </summary>
        public int? DZoomStreamId { get; set; }

        /// <summary>
        /// Zoom center X coordinate.
        /// </summary>
        public int? DZoomCenterX { get; set; }

        /// <summary>
        /// Zoom center Y coordinate.
        /// </summary>
        public int? DZoomCenterY { get; set; }

        /// <summary>
        /// Zoom scale.
        /// </summary>
        public int? DZoomScale { get; set; }

        /// <summary>
        /// Lens distortion correction.
        /// </summary>
        public bool? LensDistortionCorrection { get; set; }

        /// <summary>
        /// Enable external IR.
        /// </summary>
        public bool? EnableExternalIr { get; set; }

        /// <summary>
        /// Touch focus X.
        /// </summary>
        public int TouchFocusX { get; set; }

        /// <summary>
        /// Touch focus Y.
        /// </summary>
        public int TouchFocusY { get; set; }

        /// <summary>
        /// (IR ON) Brightness.
        /// </summary>
        public int? IrOnValBrightness { get; set; }

        /// <summary>
        /// (IR ON STS) Brightness.
        /// </summary>
        public int? IrOnStsBrightness { get; set; }

        /// <summary>
        /// (IR ON) Contrast.
        /// </summary>
        public int? IrOnValContrast { get; set; }

        /// <summary>
        /// (IR ON STS) Contrast.
        /// </summary>
        public int? IrOnStsContrast { get; set; }

        /// <summary>
        /// (IR ON) Denoise.
        /// </summary>
        public int? IrOnValDenoise { get; set; }

        /// <summary>
        /// (IR ON STS) Denoise.
        /// </summary>
        public bool? IrOnStsDenoise { get; set; }

        /// <summary>
        /// (IR ON) Hue.
        /// </summary>
        public int? IrOnValHue { get; set; }

        /// <summary>
        /// (IR ON STS) Hue.
        /// </summary>
        public bool? IrOnStsHue { get; set; }

        /// <summary>
        /// (IR ON) Saturation.
        /// </summary>
        public int? IrOnValSaturation { get; set; }

        /// <summary>
        /// (IR ON STS) Saturation.
        /// </summary>
        public bool? IrOnStsSaturation { get; set; }

        /// <summary>
        /// (IR ON) Sharpness.
        /// </summary>
        public int? IrOnValSharpness { get; set; }

        /// <summary>
        /// (IR ON STS) Sharpness.
        /// </summary>
        public bool? IrOnStsSharpness { get; set; }
    }
}
