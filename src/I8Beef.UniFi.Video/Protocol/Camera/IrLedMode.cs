namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Ir led mode.
    /// </summary>
    public enum IrLedMode
    {
        /// <summary>
        /// Auto IR.
        /// </summary>
        Auto,

        /// <summary>
        /// Manual will be returned if the mode in the GUI is set to On or Off.  In this case note the IrLedLevel.
        /// </summary>
        Manual
    }
}