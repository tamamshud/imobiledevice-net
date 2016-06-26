// <copyright file="MobileSyncClientHandle.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.MobileSync
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
    public partial class MobileSyncClientHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected MobileSyncClientHandle() : 
                base(true)
        {
        }
        
        protected MobileSyncClientHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static MobileSyncClientHandle Zero
        {
            get
            {
                return MobileSyncClientHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
#if !NETSTANDARD1_5
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
#endif
        protected override bool ReleaseHandle()
        {
            System.Diagnostics.Debug.WriteLine("Releasing {0} {1}", this.GetType().Name, this.handle);
            return (LibiMobileDevice.Instance.MobileSync.mobilesync_client_free(this.handle) == MobileSyncError.Success);
        }
        
        public static MobileSyncClientHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            MobileSyncClientHandle safeHandle;
            safeHandle = new MobileSyncClientHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static MobileSyncClientHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return MobileSyncClientHandle.DangerousCreate(unsafeHandle, true);
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "MobileSyncClientHandle");
        }
        
        public override bool Equals(object obj)
        {
            if (((obj != null) & (obj.GetType() == typeof(MobileSyncClientHandle))))
            {
                return ((MobileSyncClientHandle)obj).handle.Equals(this.handle);
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
