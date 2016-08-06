// <copyright file="PlistApi.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Plist
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class PlistApi : IPlistApi
    {
        
        /// <summary>
        /// Frees memory used globally by listplist, in
        /// particular the libxml parser
        /// </summary>
        public virtual void plist_cleanup()
        {
            PlistNativeMethods.plist_cleanup();
        }
        
        /// <summary>
        /// Create a new root plist_t type #PLIST_DICT
        /// </summary>
        /// <returns>
        /// the created plist
        /// </returns>
        public virtual PlistHandle plist_new_dict()
        {
            return PlistNativeMethods.plist_new_dict();
        }
        
        /// <summary>
        /// Create a new root plist_t type #PLIST_ARRAY
        /// </summary>
        /// <returns>
        /// the created plist
        /// </returns>
        public virtual PlistHandle plist_new_array()
        {
            return PlistNativeMethods.plist_new_array();
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_STRING
        /// </summary>
        /// <param name="val">
        /// the sting value, encoded in UTF8.
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_string(string val)
        {
            return PlistNativeMethods.plist_new_string(val);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_BOOLEAN
        /// </summary>
        /// <param name="val">
        /// the boolean value, 0 is false, other values are true.
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_bool(char val)
        {
            return PlistNativeMethods.plist_new_bool(val);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_UINT
        /// </summary>
        /// <param name="val">
        /// the unsigned integer value
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_uint(ulong val)
        {
            return PlistNativeMethods.plist_new_uint(val);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_REAL
        /// </summary>
        /// <param name="val">
        /// the real value
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_real(double val)
        {
            return PlistNativeMethods.plist_new_real(val);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_DATA
        /// </summary>
        /// <param name="val">
        /// the binary buffer
        /// </param>
        /// <param name="length">
        /// the length of the buffer
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_data(byte[] val, ulong length)
        {
            return PlistNativeMethods.plist_new_data(val, length);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_DATE
        /// </summary>
        /// <param name="sec">
        /// the number of seconds since 01/01/2001
        /// </param>
        /// <param name="usec">
        /// the number of microseconds
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_date(int sec, int usec)
        {
            return PlistNativeMethods.plist_new_date(sec, usec);
        }
        
        /// <summary>
        /// Create a new plist_t type #PLIST_UID
        /// </summary>
        /// <param name="val">
        /// the unsigned integer value
        /// </param>
        /// <returns>
        /// the created item
        /// </returns>
        public virtual PlistHandle plist_new_uid(ulong val)
        {
            return PlistNativeMethods.plist_new_uid(val);
        }
        
        /// <summary>
        /// Destruct a plist_t node and all its children recursively
        /// </summary>
        /// <param name="plist">
        /// the plist to free
        /// </param>
        public virtual void plist_free(System.IntPtr plist)
        {
            PlistNativeMethods.plist_free(plist);
        }
        
        /// <summary>
        /// Return a copy of passed node and it's children
        /// </summary>
        /// <param name="node">
        /// the plist to copy
        /// </param>
        /// <returns>
        /// copied plist
        /// </returns>
        public virtual PlistHandle plist_copy(PlistHandle node)
        {
            return PlistNativeMethods.plist_copy(node);
        }
        
        /// <summary>
        /// Get size of a #PLIST_ARRAY node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <returns>
        /// size of the #PLIST_ARRAY node
        /// </returns>
        public virtual uint plist_array_get_size(PlistHandle node)
        {
            return PlistNativeMethods.plist_array_get_size(node);
        }
        
        /// <summary>
        /// Get the nth item in a #PLIST_ARRAY node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <param name="n">
        /// the index of the item to get. Range is [0, array_size[
        /// </param>
        /// <returns>
        /// the nth item or NULL if node is not of type #PLIST_ARRAY
        /// </returns>
        public virtual PlistHandle plist_array_get_item(PlistHandle node, uint n)
        {
            return PlistNativeMethods.plist_array_get_item(node, n);
        }
        
        /// <summary>
        /// Get the index of an item. item must be a member of a #PLIST_ARRAY node.
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <returns>
        /// the node index
        /// </returns>
        public virtual uint plist_array_get_item_index(PlistHandle node)
        {
            return PlistNativeMethods.plist_array_get_item_index(node);
        }
        
        /// <summary>
        /// Set the nth item in a #PLIST_ARRAY node.
        /// The previous item at index n will be freed using #plist_free
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <param name="item">
        /// the new item at index n. The array is responsible for freeing item when it is no longer needed.
        /// </param>
        /// <param name="n">
        /// the index of the item to get. Range is [0, array_size[. Assert if n is not in range.
        /// </param>
        public virtual void plist_array_set_item(PlistHandle node, PlistHandle item, uint n)
        {
            PlistNativeMethods.plist_array_set_item(node, item, n);
        }
        
        /// <summary>
        /// Append a new item at the end of a #PLIST_ARRAY node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <param name="item">
        /// the new item. The array is responsible for freeing item when it is no longer needed.
        /// </param>
        public virtual void plist_array_append_item(PlistHandle node, PlistHandle item)
        {
            PlistNativeMethods.plist_array_append_item(node, item);
        }
        
        /// <summary>
        /// Insert a new item at position n in a #PLIST_ARRAY node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <param name="item">
        /// the new item to insert. The array is responsible for freeing item when it is no longer needed.
        /// </param>
        /// <param name="n">
        /// The position at which the node will be stored. Range is [0, array_size[. Assert if n is not in range.
        /// </param>
        public virtual void plist_array_insert_item(PlistHandle node, PlistHandle item, uint n)
        {
            PlistNativeMethods.plist_array_insert_item(node, item, n);
        }
        
        /// <summary>
        /// Remove an existing position in a #PLIST_ARRAY node.
        /// Removed position will be freed using #plist_free.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_ARRAY
        /// </param>
        /// <param name="n">
        /// The position to remove. Range is [0, array_size[. Assert if n is not in range.
        /// </param>
        public virtual void plist_array_remove_item(PlistHandle node, uint n)
        {
            PlistNativeMethods.plist_array_remove_item(node, n);
        }
        
        /// <summary>
        /// Get size of a #PLIST_DICT node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <returns>
        /// size of the #PLIST_DICT node
        /// </returns>
        public virtual uint plist_dict_get_size(PlistHandle node)
        {
            return PlistNativeMethods.plist_dict_get_size(node);
        }
        
        /// <summary>
        /// Create an iterator of a #PLIST_DICT node.
        /// The allocated iterator should be freed with the standard free function.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="iter">
        /// iterator of the #PLIST_DICT node
        /// </param>
        public virtual void plist_dict_new_iter(PlistHandle node, out PlistDictIterHandle iter)
        {
            PlistNativeMethods.plist_dict_new_iter(node, out iter);
        }
        
        /// <summary>
        /// Increment iterator of a #PLIST_DICT node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="iter">
        /// iterator of the dictionary
        /// </param>
        /// <param name="key">
        /// a location to store the key, or NULL. The caller is responsible
        /// for freeing the the returned string.
        /// </param>
        /// <param name="val">
        /// a location to store the value, or NULL. The caller should *not*
        /// free the returned value.
        /// </param>
        public virtual void plist_dict_next_item(PlistHandle node, PlistDictIterHandle iter, out string key, out PlistHandle val)
        {
            PlistNativeMethods.plist_dict_next_item(node, iter, out key, out val);
        }
        
        /// <summary>
        /// Get key associated to an item. Item must be member of a dictionary
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="key">
        /// a location to store the key. The caller is responsible for freeing the returned string.
        /// </param>
        public virtual void plist_dict_get_item_key(PlistHandle node, out string key)
        {
            PlistNativeMethods.plist_dict_get_item_key(node, out key);
        }
        
        /// <summary>
        /// Get the nth item in a #PLIST_DICT node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="key">
        /// the identifier of the item to get.
        /// </param>
        /// <returns>
        /// the item or NULL if node is not of type #PLIST_DICT. The caller should not free
        /// the returned node.
        /// </returns>
        public virtual PlistHandle plist_dict_get_item(PlistHandle node, string key)
        {
            return PlistNativeMethods.plist_dict_get_item(node, key);
        }
        
        /// <summary>
        /// Set item identified by key in a #PLIST_DICT node.
        /// The previous item identified by key will be freed using #plist_free.
        /// If there is no item for the given key a new item will be inserted.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="item">
        /// the new item associated to key
        /// </param>
        /// <param name="key">
        /// the identifier of the item to set.
        /// </param>
        public virtual void plist_dict_set_item(PlistHandle node, string key, PlistHandle item)
        {
            PlistNativeMethods.plist_dict_set_item(node, key, item);
        }
        
        /// <summary>
        /// Insert a new item into a #PLIST_DICT node.
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="item">
        /// the new item to insert
        /// </param>
        /// <param name="key">
        /// The identifier of the item to insert.
        /// </param>
        public virtual void plist_dict_insert_item(PlistHandle node, string key, PlistHandle item)
        {
            PlistNativeMethods.plist_dict_insert_item(node, key, item);
        }
        
        /// <summary>
        /// Remove an existing position in a #PLIST_DICT node.
        /// Removed position will be freed using #plist_free
        /// </summary>
        /// <param name="node">
        /// the node of type #PLIST_DICT
        /// </param>
        /// <param name="key">
        /// The identifier of the item to remove. Assert if identifier is not present.
        /// </param>
        public virtual void plist_dict_remove_item(PlistHandle node, string key)
        {
            PlistNativeMethods.plist_dict_remove_item(node, key);
        }
        
        /// <summary>
        /// Merge a dictionary into another. This will add all key/value pairs
        /// from the source dictionary to the target dictionary, overwriting
        /// any existing key/value pairs that are already present in target.
        /// </summary>
        /// <param name="target">
        /// pointer to an existing node of type #PLIST_DICT
        /// </param>
        /// <param name="source">
        /// node of type #PLIST_DICT that should be merged into target
        /// </param>
        public virtual void plist_dict_merge(out PlistHandle target, PlistHandle source)
        {
            PlistNativeMethods.plist_dict_merge(out target, source);
        }
        
        /// <summary>
        /// Get the parent of a node
        /// </summary>
        /// <param name="node">
        /// the parent (NULL if node is root)
        /// </param>
        public virtual PlistHandle plist_get_parent(PlistHandle node)
        {
            return PlistNativeMethods.plist_get_parent(node);
        }
        
        /// <summary>
        /// Get the #plist_type of a node.
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <returns>
        /// the type of the node
        /// </returns>
        public virtual PlistType plist_get_node_type(PlistHandle node)
        {
            return PlistNativeMethods.plist_get_node_type(node);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_KEY node.
        /// This function does nothing if node is not of type #PLIST_KEY
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a C-string. This function allocates the memory,
        /// caller is responsible for freeing it.
        /// </param>
        public virtual void plist_get_key_val(PlistHandle node, out string val)
        {
            PlistNativeMethods.plist_get_key_val(node, out val);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_STRING node.
        /// This function does nothing if node is not of type #PLIST_STRING
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a C-string. This function allocates the memory,
        /// caller is responsible for freeing it. Data is UTF-8 encoded.
        /// </param>
        public virtual void plist_get_string_val(PlistHandle node, out string val)
        {
            PlistNativeMethods.plist_get_string_val(node, out val);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_BOOLEAN node.
        /// This function does nothing if node is not of type #PLIST_BOOLEAN
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a uint8_t variable.
        /// </param>
        public virtual void plist_get_bool_val(PlistHandle node, ref char val)
        {
            PlistNativeMethods.plist_get_bool_val(node, ref val);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_UINT node.
        /// This function does nothing if node is not of type #PLIST_UINT
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a uint64_t variable.
        /// </param>
        public virtual void plist_get_uint_val(PlistHandle node, ref ulong val)
        {
            PlistNativeMethods.plist_get_uint_val(node, ref val);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_REAL node.
        /// This function does nothing if node is not of type #PLIST_REAL
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a double variable.
        /// </param>
        public virtual void plist_get_real_val(PlistHandle node, ref double val)
        {
            PlistNativeMethods.plist_get_real_val(node, ref val);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_DATA node.
        /// This function does nothing if node is not of type #PLIST_DATA
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to an unallocated char buffer. This function allocates the memory,
        /// caller is responsible for freeing it.
        /// </param>
        /// <param name="length">
        /// the length of the buffer
        /// </param>
        public virtual void plist_get_data_val(PlistHandle node, out string val, ref ulong length)
        {
            PlistNativeMethods.plist_get_data_val(node, out val, ref length);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_DATE node.
        /// This function does nothing if node is not of type #PLIST_DATE
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="sec">
        /// a pointer to an int32_t variable. Represents the number of seconds since 01/01/2001.
        /// </param>
        /// <param name="usec">
        /// a pointer to an int32_t variable. Represents the number of microseconds
        /// </param>
        public virtual void plist_get_date_val(PlistHandle node, ref int sec, ref int usec)
        {
            PlistNativeMethods.plist_get_date_val(node, ref sec, ref usec);
        }
        
        /// <summary>
        /// Get the value of a #PLIST_UID node.
        /// This function does nothing if node is not of type #PLIST_UID
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// a pointer to a uint64_t variable.
        /// </param>
        public virtual void plist_get_uid_val(PlistHandle node, ref ulong val)
        {
            PlistNativeMethods.plist_get_uid_val(node, ref val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_KEY
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the key value
        /// </param>
        public virtual void plist_set_key_val(PlistHandle node, string val)
        {
            PlistNativeMethods.plist_set_key_val(node, val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_STRING
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the string value. The string is copied when set and will be
        /// freed by the node.
        /// </param>
        public virtual void plist_set_string_val(PlistHandle node, string val)
        {
            PlistNativeMethods.plist_set_string_val(node, val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_BOOLEAN
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the boolean value
        /// </param>
        public virtual void plist_set_bool_val(PlistHandle node, char val)
        {
            PlistNativeMethods.plist_set_bool_val(node, val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_UINT
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the unsigned integer value
        /// </param>
        public virtual void plist_set_uint_val(PlistHandle node, ulong val)
        {
            PlistNativeMethods.plist_set_uint_val(node, val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_REAL
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the real value
        /// </param>
        public virtual void plist_set_real_val(PlistHandle node, double val)
        {
            PlistNativeMethods.plist_set_real_val(node, val);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_DATA
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the binary buffer. The buffer is copied when set and will
        /// be freed by the node.
        /// </param>
        /// <param name="length">
        /// the length of the buffer
        /// </param>
        public virtual void plist_set_data_val(PlistHandle node, string val, ulong length)
        {
            PlistNativeMethods.plist_set_data_val(node, val, length);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_DATE
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="sec">
        /// the number of seconds since 01/01/2001
        /// </param>
        /// <param name="usec">
        /// the number of microseconds
        /// </param>
        public virtual void plist_set_date_val(PlistHandle node, int sec, int usec)
        {
            PlistNativeMethods.plist_set_date_val(node, sec, usec);
        }
        
        /// <summary>
        /// Set the value of a node.
        /// Forces type of node to #PLIST_UID
        /// </summary>
        /// <param name="node">
        /// the node
        /// </param>
        /// <param name="val">
        /// the unsigned integer value
        /// </param>
        public virtual void plist_set_uid_val(PlistHandle node, ulong val)
        {
            PlistNativeMethods.plist_set_uid_val(node, val);
        }
        
        /// <summary>
        /// Export the #plist_t structure to XML format.
        /// </summary>
        /// <param name="plist">
        /// the root node to export
        /// </param>
        /// <param name="plist_xml">
        /// a pointer to a C-string. This function allocates the memory,
        /// caller is responsible for freeing it. Data is UTF-8 encoded.
        /// </param>
        /// <param name="length">
        /// a pointer to an uint32_t variable. Represents the length of the allocated buffer.
        /// </param>
        public virtual void plist_to_xml(PlistHandle plist, out string plistXml, ref uint length)
        {
            PlistNativeMethods.plist_to_xml(plist, out plistXml, ref length);
        }
        
        /// <summary>
        /// Frees the memory allocated by plist_to_xml
        /// </summary>
        /// <param name="plist_bin">
        /// The object allocated by plist_to_xml
        /// </param>
        public virtual void plist_to_xml_free(System.IntPtr plistXml)
        {
            PlistNativeMethods.plist_to_xml_free(plistXml);
        }
        
        /// <summary>
        /// Export the #plist_t structure to binary format.
        /// </summary>
        /// <param name="plist">
        /// the root node to export
        /// </param>
        /// <param name="plist_bin">
        /// a pointer to a char* buffer. This function allocates the memory,
        /// caller is responsible for freeing it.
        /// </param>
        /// <param name="length">
        /// a pointer to an uint32_t variable. Represents the length of the allocated buffer.
        /// </param>
        public virtual void plist_to_bin(PlistHandle plist, out byte[] plistBin, ref uint length)
        {
            PlistNativeMethods.plist_to_bin(plist, out plistBin, ref length);
        }
        
        /// <summary>
        /// Frees the memory allocated by plist_to_bin
        /// </summary>
        /// <param name="plist_bin">
        /// The object allocated by plist_to_bin
        /// </param>
        public virtual void plist_to_bin_free(System.IntPtr plistBin)
        {
            PlistNativeMethods.plist_to_bin_free(plistBin);
        }
        
        /// <summary>
        /// Import the #plist_t structure from XML format.
        /// </summary>
        /// <param name="plist_xml">
        /// a pointer to the xml buffer.
        /// </param>
        /// <param name="length">
        /// length of the buffer to read.
        /// </param>
        /// <param name="plist">
        /// a pointer to the imported plist.
        /// </param>
        public virtual void plist_from_xml(string plistXml, uint length, out PlistHandle plist)
        {
            PlistNativeMethods.plist_from_xml(plistXml, length, out plist);
        }
        
        /// <summary>
        /// Import the #plist_t structure from binary format.
        /// </summary>
        /// <param name="plist_bin">
        /// a pointer to the xml buffer.
        /// </param>
        /// <param name="length">
        /// length of the buffer to read.
        /// </param>
        /// <param name="plist">
        /// a pointer to the imported plist.
        /// </param>
        public virtual void plist_from_bin(string plistBin, uint length, out PlistHandle plist)
        {
            PlistNativeMethods.plist_from_bin(plistBin, length, out plist);
        }
        
        /// <summary>
        /// Get a node from its path. Each path element depends on the associated father node type.
        /// For Dictionaries, var args are casted to const char*, for arrays, var args are caster to uint32_t
        /// Search is breath first order.
        /// </summary>
        /// <param name="plist">
        /// the node to access result from.
        /// </param>
        /// <param name="length">
        /// length of the path to access
        /// </param>
        /// <returns>
        /// the value to access.
        /// </returns>
        public virtual PlistHandle plist_access_path(PlistHandle plist, uint length)
        {
            return PlistNativeMethods.plist_access_path(plist, length);
        }
        
        /// <summary>
        /// Variadic version of #plist_access_path.
        /// </summary>
        /// <param name="plist">
        /// the node to access result from.
        /// </param>
        /// <param name="length">
        /// length of the path to access
        /// </param>
        /// <param name="v">
        /// list of array's index and dic'st key
        /// </param>
        /// <returns>
        /// the value to access.
        /// </returns>
        public virtual PlistHandle plist_access_pathv(PlistHandle plist, uint length, System.IntPtr v)
        {
            return PlistNativeMethods.plist_access_pathv(plist, length, v);
        }
        
        /// <summary>
        /// Compare two node values
        /// </summary>
        /// <param name="node_l">
        /// left node to compare
        /// </param>
        /// <param name="node_r">
        /// rigth node to compare
        /// </param>
        /// <returns>
        /// TRUE is type and value match, FALSE otherwise.
        /// </returns>
        public virtual sbyte plist_compare_node_value(PlistHandle nodeL, PlistHandle nodeR)
        {
            return PlistNativeMethods.plist_compare_node_value(nodeL, nodeR);
        }
    }
}
