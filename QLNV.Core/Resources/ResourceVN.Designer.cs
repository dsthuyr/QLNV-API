//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNV.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceVN {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceVN() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("QLNV.Core.Resources.ResourceVN", typeof(ResourceVN).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Danh sách nhân viên.
        /// </summary>
        internal static string VN_NameExcelSheet_EmployeeList {
            get {
                return ResourceManager.GetString("VN_NameExcelSheet_EmployeeList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phòng ban không được phép để trống..
        /// </summary>
        internal static string VN_ValidateError_DepartmentNotEmpty {
            get {
                return ResourceManager.GetString("VN_ValidateError_DepartmentNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ngày sinh không được lớn hơn ngày hiện tại..
        /// </summary>
        internal static string VN_ValidateError_DOBNotValid {
            get {
                return ResourceManager.GetString("VN_ValidateError_DOBNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email không hợp lệ..
        /// </summary>
        internal static string VN_ValidateError_EmailNotValid {
            get {
                return ResourceManager.GetString("VN_ValidateError_EmailNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại..
        /// </summary>
        internal static string VN_ValidateError_EmployeeCodeDuplilcate {
            get {
                return ResourceManager.GetString("VN_ValidateError_EmployeeCodeDuplilcate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên không được phép để trống..
        /// </summary>
        internal static string VN_ValidateError_EmployeeCodeNotEmpty {
            get {
                return ResourceManager.GetString("VN_ValidateError_EmployeeCodeNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên không được phép lớn hơn 20 kí tự..
        /// </summary>
        internal static string VN_ValidateError_EmployeeCodeToLong {
            get {
                return ResourceManager.GetString("VN_ValidateError_EmployeeCodeToLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên nhân viên không được phép để trống..
        /// </summary>
        internal static string VN_ValidateError_EmployeeNameNotEmpty {
            get {
                return ResourceManager.GetString("VN_ValidateError_EmployeeNameNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi sảy ra, vui lòng liên hệ để được hỗ trợ..
        /// </summary>
        internal static string VN_ValidateError_HaveError {
            get {
                return ResourceManager.GetString("VN_ValidateError_HaveError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu đầu vào không hợp lệ..
        /// </summary>
        internal static string VN_ValidateError_InputNotValid {
            get {
                return ResourceManager.GetString("VN_ValidateError_InputNotValid", resourceCulture);
            }
        }
    }
}
