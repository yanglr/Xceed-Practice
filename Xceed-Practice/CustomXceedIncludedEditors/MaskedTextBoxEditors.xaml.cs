﻿using System;
using System.Net;
using System.Text;
using System.Windows;

using Xceed.Wpf.Controls;

namespace CustomXceedIncludedEditors
{
  public partial class MaskedTextBoxEditors : ResourceDictionary
  {
    private void IPAddressEditor_QueryTextFromValue( object sender, QueryTextFromValueEventArgs e )
    {
      IPAddress ipAddress = e.Value as IPAddress;

      if( ipAddress == null )
        return;

      byte[] bytes = ipAddress.GetAddressBytes();

      StringBuilder ipBuilder = new StringBuilder();

      for( int i = 0; i < bytes.Length; i++ )
      {
        ipBuilder.Append( bytes[ i ].ToString( "00#" ) + "." );
      }

      ipBuilder.Remove( ipBuilder.Length - 1, 1 );

      e.Text = ipBuilder.ToString();
    }

    private void IPAddressEditor_QueryValueFromText( object sender, QueryValueFromTextEventArgs e )
    {
      if( String.IsNullOrEmpty( e.Text ) )
      {
        e.Value = IPAddress.None;
        e.HasParsingError = false;
        return;
      }

      string[] ipParts = e.Text.Split( new char[] { '.' } );
      byte[] bytes = new byte[ ipParts.Length ];

      for( int i = 0; i < ipParts.Length; i++ )
      {
        if( !byte.TryParse( ipParts[ i ], out bytes[ i ] ) )
        {
          e.Value = IPAddress.None;
          e.HasParsingError = true;
          return;
        }
      }

      e.Value = new IPAddress( bytes );
      e.HasParsingError = false;
    }

    private void OnAutoCompletingMaskHandler( object sender, AutoCompletingMaskEventArgs e )
    {
      // This handler shifts the edited positions up to the next literal and inserts zeroes in the remaining positions.
      StringBuilder autoCompletionBuilder = new StringBuilder();

      e.AutoCompleteStartPosition = e.MaskedTextProvider.FindNonEditPositionFrom( e.StartPosition, false ) + 1;
      int nextSeparatorIndex = e.MaskedTextProvider.FindNonEditPositionFrom( e.StartPosition, true );

      for( int i = e.AutoCompleteStartPosition; i < nextSeparatorIndex; i++ )
      {
        if( !e.MaskedTextProvider.IsAvailablePosition( i ) )
        {
          autoCompletionBuilder.Append( e.MaskedTextProvider[ i ] );
        }
        else
        {
          autoCompletionBuilder.Insert( 0, '0' );
        }
      }

      e.AutoCompleteText = autoCompletionBuilder.ToString();
    }
  }
}
