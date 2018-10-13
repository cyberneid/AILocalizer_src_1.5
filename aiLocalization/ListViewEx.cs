#region Copyright ArtfulBits Inc. 2005 - 2009
//
//  Copyright ArtfulBits Inc. 2005 - 2009. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  info@artfulbits.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

#region file usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace Artfulbits.Android.Localization.GUI.Controls
{
  /// <summary>
  /// List view control that allow show and hide columns.
  /// </summary>
  /// <remarks>Class does not support well initialization logic. That is why 
  /// after initialization control can have wrong width's of hidden collumns.</remarks>
  public class ListViewEx : ListView
  {
    #region Class constants
    /// <summary>
    /// 
    /// </summary>
    protected internal const int WM_NOTIFY = 0x004E;
    /// <summary></summary>
    protected const int LVM_FIRST = 0x1000;
    /// <summary></summary>
    protected const int LVM_SETCOLUMNORDERARRAY = ( LVM_FIRST + 58 );
    /// <summary></summary>
    protected const int LVM_GETCOLUMNORDERARRAY = ( LVM_FIRST + 59 );
    /// <summary>
    /// 
    /// </summary>
    protected internal enum CustomDrawDrawStateFlags
    {
      /// <summary>
      /// 
      /// </summary>
      CDDS_PREPAINT = 0x00000001,
      /// <summary>
      /// 
      /// </summary>
      CDDS_POSTPAINT = 0x00000002,
      /// <summary>
      /// 
      /// </summary>
      CDDS_PREERASE = 0x00000003,
      /// <summary>
      /// 
      /// </summary>
      CDDS_POSTERASE = 0x00000004,
      /// <summary>
      /// 
      /// </summary>
      CDDS_ITEM = 0x00010000,
      /// <summary>
      /// 
      /// </summary>
      CDDS_ITEMPREPAINT = ( CDDS_ITEM | CDDS_PREPAINT ),
      /// <summary>
      /// 
      /// </summary>
      CDDS_ITEMPOSTPAINT = ( CDDS_ITEM | CDDS_POSTPAINT ),
      /// <summary>
      /// 
      /// </summary>
      CDDS_ITEMPREERASE = ( CDDS_ITEM | CDDS_PREERASE ),
      /// <summary>
      /// 
      /// </summary>
      CDDS_ITEMPOSTERASE = ( CDDS_ITEM | CDDS_POSTERASE ),
      /// <summary>
      /// 
      /// </summary>
      CDDS_SUBITEM = 0x00020000,
      /// <summary>
      /// 
      /// </summary>
      CDDS_SUBITEMPREPAINT = ( CDDS_ITEMPREPAINT | CDDS_SUBITEM ),
      /// <summary>
      /// 
      /// </summary>
      CDDS_SUBITEMPOSTPAINT = ( CDDS_ITEMPOSTPAINT | CDDS_SUBITEM )
    }
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    protected internal enum CustomDrawReturnFlags
    {
      /// <summary>
      /// 
      /// </summary>
      CDRF_DODEFAULT = 0x00000000,
      /// <summary>
      /// 
      /// </summary>
      CDRF_NEWFONT = 0x00000002,
      /// <summary>
      /// 
      /// </summary>
      CDRF_SKIPDEFAULT = 0x00000004,
      /// <summary>
      /// 
      /// </summary>
      CDRF_NOTIFYPOSTPAINT = 0x00000010,
      /// <summary>
      /// 
      /// </summary>
      CDRF_NOTIFYITEMDRAW = 0x00000020,
      /// <summary>
      /// 
      /// </summary>
      CDRF_NOTIFYSUBITEMDRAW = 0x00000020,
      /// <summary>
      /// 
      /// </summary>
      CDRF_NOTIFYPOSTERASE = 0x00000040
    }
    /// <summary>
    /// 
    /// </summary>
    protected internal enum NotificationMessages
    {
      /// <summary>
      /// 
      /// </summary>
      NM_FIRST = ( 0 - 0 ),
      /// <summary>
      /// 
      /// </summary>
      NM_CUSTOMDRAW = ( NM_FIRST - 12 ),
      /// <summary>
      /// 
      /// </summary>
      NM_NCHITTEST = ( NM_FIRST - 14 )
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    protected internal struct NMHDR
    {
      /// <summary>
      /// 
      /// </summary>
      public IntPtr hwndFrom;
      /// <summary>
      /// 
      /// </summary>
      public int idFrom;
      /// <summary>
      /// 
      /// </summary>
      public int code;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    protected internal struct NMCUSTOMDRAW
    {
      /// <summary>
      /// 
      /// </summary>
      public NMHDR hdr;
      /// <summary>
      /// 
      /// </summary>
      public int dwDrawStage;
      /// <summary>
      /// 
      /// </summary>
      public IntPtr hdc;
      /// <summary>
      /// 
      /// </summary>
      public RECT rc;
      /// <summary>
      /// 
      /// </summary>
      public int dwItemSpec;
      /// <summary>
      /// 
      /// </summary>
      public int uItemState;
      /// <summary>
      /// 
      /// </summary>
      public int lItemlParam;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    protected internal struct RECT
    {
      /// <summary>
      /// 
      /// </summary>
      public int left;
      /// <summary>
      /// 
      /// </summary>
      public int top;
      /// <summary>
      /// 
      /// </summary>
      public int right;
      /// <summary>
      /// 
      /// </summary>
      public int bottom;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="rect"></param>
      /// <returns></returns>
      public static implicit operator Rectangle( RECT rect )
      {
        return Rectangle.FromLTRB( rect.left, rect.top, rect.right, rect.bottom );
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="rect"></param>
      /// <returns></returns>
      public static implicit operator Size( RECT rect )
      {
        return new Size( rect.right - rect.left, rect.bottom - rect.top );
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="rect"></param>
      /// <returns></returns>
      public static explicit operator RECT( Rectangle rect )
      {
        RECT rc = new RECT();

        rc.left = rect.Left;
        rc.right = rect.Right;
        rc.top = rect.Top;
        rc.bottom = rect.Bottom;

        return rc;
      }
    }
    #endregion

    #region Class members
    /// <summary></summary>
    private Dictionary<ColumnHeader, int> m_hidden;
    /// <summary></summary>
    private ListViewColumnSorter m_lvwColumnSorter = new ListViewColumnSorter();
    /// <summary></summary>
    private bool m_bSortOnClick = true;
    #endregion

    #region Class properties
    /// <summary>
    /// Gets/Sets is on click list view will sort items or not.
    /// </summary>
    [
    Browsable( true ),
    DefaultValue( true ),
    Category( "Behavior" ),
    Description( "Gets/Sets is on click list view will sort items or not." )
    ]
    public bool SortOnColumnClick
    {
      get
      {
        return m_bSortOnClick;
      }
      set
      {
        m_bSortOnClick = value;
      }
    }
    /// <summary></summary>
    [
    Browsable( false )
    ]
    protected Dictionary<ColumnHeader, int> HiddenColumnsWidth
    {
      get
      {
        if( m_hidden == null )
          m_hidden = new Dictionary<ColumnHeader, int>( this.Columns.Count );

        return m_hidden;
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="header"></param>
    /// <returns></returns>
    [
    Browsable( false )
    ]
    public int this[ ColumnHeader header ]
    {
      get
      {
        if( !this.HiddenColumnsWidth.ContainsKey( header ) )
        {
          this.HiddenColumnsWidth[ header ] = -1;
        }

        return this.HiddenColumnsWidth[ header ];
      }
      set
      {
        this.HiddenColumnsWidth[ header ] = value;
      }
    }
    /// <summary>
    /// GET/SET order of columns in ListView
    /// </summary>
    [
    Browsable( false )
    ]
    public int[] ColumnOrderArray
    {
      get
      {
        int iCount = this.Columns.Count;
        int[] array = new int[ iCount ];

        if( this.IsHandleCreated )
        {
          IntPtr ar = Marshal.AllocHGlobal( iCount * Marshal.SizeOf( typeof( int ) ) );
          Marshal.Copy( array, 0, ar, iCount );
          SendMessage( this.Handle, LVM_GETCOLUMNORDERARRAY, iCount, ar );
          Marshal.Copy( ar, array, 0, iCount );
          Marshal.FreeHGlobal( ar );
        }

        return array;
      }
      set
      {
        int iCount = this.Columns.Count;
        if( value.Length > iCount || value.Length < iCount )
          return;

        if( this.IsHandleCreated )
        {
          IntPtr ar = Marshal.AllocHGlobal( iCount * Marshal.SizeOf( typeof( int ) ) );
          Marshal.Copy( value, 0, ar, iCount );
          SendMessage( this.Handle, LVM_SETCOLUMNORDERARRAY, iCount, ar );
          Marshal.FreeHGlobal( ar );
        }
        else
        {
          // TODO: simple column headers reorder needed here
        }
      }
    }
    #endregion

    #region Class events
    /// <summary></summary>
    public event EventHandler<ColumnClickEventArgs> ColumnGroupping;
    #endregion

    #region Class initialize/finilize methods
    /// <summary>
    /// 
    /// </summary>
    public ListViewEx()
    {
      this.ListViewItemSorter = m_lvwColumnSorter;
    }
    #endregion

    #region Class overrides
    /// <summary></summary>
    /// <param name="e"></param>
    protected override void OnColumnWidthChanging( ColumnWidthChangingEventArgs e )
    {
      ColumnHeader header = this.Columns[ e.ColumnIndex ];

      this.HiddenColumnsWidth[ header ] = ( e.NewWidth == 0 ) ? header.Width : -1;

      base.OnColumnWidthChanging( e );
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnColumnClick( ColumnClickEventArgs e )
    {
      if( ( Control.ModifierKeys & Keys.Control ) == Keys.Control )
      {
        this.RecreateHandle();

        OnColumnGroupping( e );
      }
      else if( this.SortOnColumnClick )
      {
        if( this.ShowGroups && this.Groups.Count > 0 )
          this.ShowGroups = false;

        // Determine if clicked column is already the column that is being sorted.
        if( e.Column == m_lvwColumnSorter.SortColumn )
        {
          // Reverse the current sort direction for this column.
          if( m_lvwColumnSorter.Order == SortOrder.Ascending )
          {
            m_lvwColumnSorter.Order = SortOrder.Descending;
          }
          else
          {
            m_lvwColumnSorter.Order = SortOrder.Ascending;
          }
        }
        else
        {
          Invalidate( true ); // force invalidation of header

          // Set the column number that is to be sorted; default to ascending.
          m_lvwColumnSorter.SortColumn = e.Column;
          m_lvwColumnSorter.Order = SortOrder.Ascending;
        }

        // Perform the sort with these new sort options.
        this.Sort();
      }

      base.OnColumnClick( e );
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected override void WndProc( ref System.Windows.Forms.Message m )
    {
      switch( m.Msg )
      {
        case WM_NOTIFY:
          {
            base.WndProc( ref m );
            NMHDR nm1 = ( NMHDR )m.GetLParam( typeof( NMHDR ) );

            switch( nm1.code )
            {
              case ( int )NotificationMessages.NM_CUSTOMDRAW:
                {
                  m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_DODEFAULT;
                  NMCUSTOMDRAW nmcd = ( NMCUSTOMDRAW )m.GetLParam( typeof( NMCUSTOMDRAW ) );

                  switch( nmcd.dwDrawStage )
                  {
                    case ( int )CustomDrawDrawStateFlags.CDDS_PREPAINT:
                      CddsPrePaint( ref m );
                      break;

                    case ( int )CustomDrawDrawStateFlags.CDDS_POSTPAINT:
                      CddsPostPaint( ref m );
                      break;

                    case ( int )CustomDrawDrawStateFlags.CDDS_ITEMPREPAINT:
                      CddsItemPrePaint( ref m );
                      break;

                    case ( int )CustomDrawDrawStateFlags.CDDS_ITEMPOSTPAINT:
                      CddsItemPostPaint( ref m );
                      break;

                    case ( int )CustomDrawDrawStateFlags.CDDS_SUBITEMPREPAINT:
                      CddsSubItemPrePaint( ref m );
                      break;

                    case ( int )CustomDrawDrawStateFlags.CDDS_SUBITEMPOSTPAINT:
                      CddsSubItemPostPaint( ref m );
                      break;
                  }
                }
                break;
            }
          }
          break;

        default:
          base.WndProc( ref m );
          break;
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsPrePaint( ref System.Windows.Forms.Message m )
    { 
      // Ask for Item painting notifications
      m.Result = ( IntPtr )(
        CustomDrawReturnFlags.CDRF_NOTIFYITEMDRAW |
        CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT |
        CustomDrawReturnFlags.CDRF_NOTIFYSUBITEMDRAW );
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsPostPaint( ref System.Windows.Forms.Message m )
    {
      m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_DODEFAULT;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsSubItemPostPaint( ref System.Windows.Forms.Message m )
    {
      m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_DODEFAULT;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsSubItemPrePaint( ref System.Windows.Forms.Message m )
    {
      m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsItemPostPaint( ref System.Windows.Forms.Message m )
    {
      NMCUSTOMDRAW nmcd = ( NMCUSTOMDRAW )m.GetLParam( typeof( NMCUSTOMDRAW ) );

      int iColumn = nmcd.dwItemSpec;

      Rectangle rcHeader = new Rectangle( nmcd.rc.left,
        nmcd.rc.top,
        nmcd.rc.right - nmcd.rc.left,
        nmcd.rc.bottom - nmcd.rc.top );

      using( Graphics g = Graphics.FromHdc( nmcd.hdc ) )
      {
        ColumnHeaderPaintEventArg pe = new ColumnHeaderPaintEventArg( g, rcHeader, this.Columns[ iColumn ] );

        OnColumnHeaderPaint( pe );
      }

      // free resources and say to control skip default drawing
      m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_SKIPDEFAULT;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected virtual void CddsItemPrePaint( ref System.Windows.Forms.Message m )
    {
      m.Result = ( IntPtr )CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pe"></param>
    protected virtual void OnColumnHeaderPaint( ColumnHeaderPaintEventArg pe )
    {
      if( this.SortOnColumnClick )
      {
        if( m_lvwColumnSorter.SortColumn == pe.ColumnHeader.Index )
        {
          Rectangle rc = pe.ClipRectangle;
          Rectangle rcArrow = new Rectangle( rc.Right - 8 - 8, rc.Top + 4, 8, 8 );

          if( m_lvwColumnSorter.Order == SortOrder.Ascending )
          {
            DrawDownArrow( pe.Graphics, rcArrow );
          }
          else if( m_lvwColumnSorter.Order == SortOrder.Descending )
          {
            DrawUpArrow( pe.Graphics, rcArrow );
          }
        }
      }
    }
    /// <summary></summary>
    /// <param name="e"></param>
    protected virtual void OnColumnGroupping( ColumnClickEventArgs e )
    {
      if( null != ColumnGroupping )
      {
        ColumnGroupping( this, e );
      }
    }
    #endregion

    #region Class public methods
    /// <summary></summary>
    /// <param name="index"></param>
    public void ShowColumn( int index )
    {
      ColumnHeader header = this.Columns[ index ];
      int value = this.HiddenColumnsWidth[ header ];

      if( header.Width == 0 && value > 0 )
      {
        header.Width = value;
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void HideColumn( int index )
    {
      ColumnHeader header = this.Columns[ index ];

      if( header.Width > 0 )
      {
        header.Width = 0;
      }
    }
    #endregion

    #region class utility methods
    /// <summary></summary>
    /// <param name="hWnd"></param>
    /// <param name="msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    protected static extern IntPtr SendMessage( IntPtr hWnd, int msg, int wParam, IntPtr lParam );
    /// <summary>
    /// Draw arrow of Descading order
    /// </summary>
    /// <param name="g"></param>
    /// <param name="rc"></param>
    public static void DrawUpArrow( Graphics g, Rectangle rc )
    {
      if( null == g )
        throw new ArgumentNullException( "g" );

      int xTop = rc.Left + rc.Width / 2;
      int yTop = ( rc.Height - 6 ) / 2;

      int xLeft = xTop - 4;
      int yLeft = yTop + 6;

      int xRight = xTop + 4;
      int yRight = yTop + 6;

      g.DrawLine( SystemPens.ControlDarkDark, xLeft, rc.Top + yLeft, xTop, rc.Top + yTop );
      g.DrawLine( SystemPens.ControlLightLight, xRight, rc.Top + yRight, xTop, rc.Top + yTop );
      g.DrawLine( SystemPens.ControlLight, xLeft, rc.Top + yLeft, xRight, rc.Top + yRight );
    }
    /// <summary>
    /// Draw arrow of Ascending order
    /// </summary>
    /// <param name="g"></param>
    /// <param name="rc"></param>
    public static void DrawDownArrow( Graphics g, Rectangle rc )
    {
      if( null == g )
        throw new ArgumentNullException( "g" );

      int xBottom = rc.Left + rc.Width / 2;

      int xLeft = xBottom - 4;
      int yLeft = ( rc.Height - 6 ) / 2;

      int xRight = xBottom + 4;
      int yRight = ( rc.Height - 6 ) / 2;

      int yBottom = yRight + 6;

      g.DrawLine( SystemPens.ControlDarkDark, xLeft, rc.Top + yLeft, xBottom, rc.Top + yBottom );
      g.DrawLine( SystemPens.ControlLightLight, xRight, rc.Top + yRight, xBottom, rc.Top + yBottom );
      g.DrawLine( SystemPens.ControlDark, xLeft, rc.Top + yLeft, xRight, rc.Top + yRight );
    }
    #endregion
  }

  /// <summary>
  /// This class is an implementation of the 'IComparer' interface.
  /// </summary>
  /// <remarks>http://support.microsoft.com/kb/319401</remarks>
  public class ListViewColumnSorter : IComparer
  {
    #region Class members
    /// <summary>
    /// Specifies the column to be sorted
    /// </summary>
    private int m_columnToSort;
    /// <summary>
    /// Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder m_orderOfSort;
    /// <summary>
    /// Case insensitive comparer object
    /// </summary>
    private CaseInsensitiveComparer m_comparer;
    #endregion

    #region Class initialize/finilize methods
    /// <summary>
    /// Class constructor.  Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
      // Initialize the column to '0'
      m_columnToSort = 0;

      // Initialize the sort order to 'none'
      m_orderOfSort = SortOrder.None;

      // Initialize the CaseInsensitiveComparer object
      m_comparer = new CaseInsensitiveComparer();
    }
    #endregion

    #region Class overrides
    /// <summary>
    /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    public virtual int Compare( object x, object y )
    {
      int compareResult;
      ListViewItem listviewX, listviewY;

      // Cast the objects to be compared to ListViewItem objects
      listviewX = ( ListViewItem )x;
      listviewY = ( ListViewItem )y;

      IComparer localComparer = m_comparer;

      if( listviewX.ListView.Columns[ m_columnToSort ] is SortableColumnHeader )
      {
        if( ( ( SortableColumnHeader )listviewX.ListView.Columns[ m_columnToSort ] ).Comparer != null )
        {           
          localComparer = ( ( SortableColumnHeader )listviewX.ListView.Columns[ m_columnToSort ] ).Comparer;
        }
      }
      else if( listviewX is IComparer )
      {
        localComparer = ( IComparer )listviewX;
      } 

      // Compare the two items
      if( localComparer is ListViewItemImageKeyComparer )
        compareResult = localComparer.Compare( listviewX,
        listviewY );
      else
        compareResult = localComparer.Compare( listviewX.SubItems[ m_columnToSort ].Text,
        listviewY.SubItems[ m_columnToSort ].Text );

      // Calculate correct return value based on object comparison
      if( m_orderOfSort == SortOrder.Ascending )
      {
        // Ascending sort is selected, return normal result of compare operation
        return compareResult;
      }
      else if( m_orderOfSort == SortOrder.Descending )
      {
        // Descending sort is selected, return negative result of compare operation
        return ( -compareResult );
      }
      else
      {
        // Return '0' to indicate they are equal
        return 0;
      }
    }
    #endregion

    #region Class properties
    /// <summary>
    /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    /// </summary>
    public int SortColumn
    {
      set
      {
        m_columnToSort = value;
      }
      get
      {
        return m_columnToSort;
      }
    }
    /// <summary>
    /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    /// </summary>
    public SortOrder Order
    {
      set
      {
        m_orderOfSort = value;
      }
      get
      {
        return m_orderOfSort;
      }
    }
    #endregion
  }

  /// <summary>
  /// 
  /// </summary>
  public class ColumnHeaderPaintEventArg : PaintEventArgs
  {
    #region Class members
    /// <summary>
    /// 
    /// </summary>
    private ColumnHeader m_column;
    #endregion

    #region Class properties
    /// <summary>
    /// 
    /// </summary>
    public ColumnHeader ColumnHeader
    {
      get
      {
        return m_column;
      }
    }
    #endregion

    #region Class initialize/finilize methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="g"></param>
    /// <param name="clip"></param>
    /// <param name="header"></param>
    public ColumnHeaderPaintEventArg( Graphics g, Rectangle clip, ColumnHeader header )
      : base( g, clip )
    {
      m_column = header;
    }
    #endregion
  }

  /// <summary></summary>
  ///  This class is derived from 'ColumnHeader' and implement the 'ICloneable' interface.
  /// <summary></summary>
  public class SortableColumnHeader :
    ColumnHeader,
    ICloneable
  {
    #region Clas members
    /// <summary></summary>
    private IComparer m_comparer;
    #endregion

    #region Class properties
    /// <summary>
    /// 
    /// </summary>
    [
    Category( "Behavior" ),
    DefaultValue( null ),
    Description( "Set specific comparer for Column and it data." ),
    ]
    public IComparer Comparer
    {
      get
      {
        return m_comparer;
      }
      set
      {
        m_comparer = value;
      }
    }
    #endregion

    #region ICloneable Members
    /// <summary></summary>
    /// <returns></returns>
    object ICloneable.Clone()
    {
      return this.Clone();
    }
    /// <summary></summary>
    /// <returns></returns>
    public new SortableColumnHeader Clone()
    {
      return this.MemberwiseClone() as SortableColumnHeader;
    }
    #endregion
  }

  /// <summary>
  /// Class ListViewItemImageKeyComparer for comparation two ListView items with icons in their fields      
  /// </summary>
  public class ListViewItemImageKeyComparer :
    Component,
    IComparer
  {
    #region Class public methods
    /// <summary>
    /// This method is inherited from the ListViewItemImageKeyComparer interface.  It compares the two objects passed using a case insensitive comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    public int Compare( object x, object y )
    {
      ListViewItem listviewX, listviewY;

      // Cast the objects to be compared to ListViewItem objects
      listviewX = ( ListViewItem )x;
      listviewY = ( ListViewItem )y;

      if( listviewX == null || listviewY == null )
        throw new ArgumentException( "Comparer is suitable only for ListView control" );

      return StringComparer.InvariantCulture.Compare(listviewX.ImageKey, listviewY.ImageKey );
    }
    #endregion
  }
}
