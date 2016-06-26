// <copyright file="SyslogRelayClientHandle.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.SyslogRelay
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
#if !NETSTANDARD1_5
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, UnmanagedCode=true)]
#endif
#if !NETSTANDARD1_5
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, UnmanagedCode=true)]
#endif
    public partial class SyslogRelayClientHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected SyslogRelayClientHandle() : 
                base(true)
        {
        }
        
        protected SyslogRelayClientHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static SyslogRelayClientHandle Zero
        {
            get
            {
                return SyslogRelayClientHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
#if !NETSTANDARD1_5
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
#endif
        protected override bool ReleaseHandle()
        {
            System.Diagnostics.Debug.WriteLine("Releasing {0} {1}", this.GetType().Name, this.handle);
            return (LibiMobileDevice.Instance.SyslogRelay.syslog_relay_client_free(this.handle) == SyslogRelayError.Success);
        }
        
        public static SyslogRelayClientHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            SyslogRelayClientHandle safeHandle;
            safeHandle = new SyslogRelayClientHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static SyslogRelayClientHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return SyslogRelayClientHandle.DangerousCreate(unsafeHandle, true);
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "SyslogRelayClientHandle");
        }
        
        public override bool Equals(object obj)
        {
            if (((obj != null) & (obj.GetType() == typeof(SyslogRelayClientHandle))))
            {
                return ((SyslogRelayClientHandle)obj).handle.Equals(this.handle);
            }
            else
            {
                return false;
            }
        }
        
        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }
    }
}
