Module Modulo
    Public THREAD As Threading.Thread
    Public V As Long()
    Public VD As Long()
    Public VECTOR_INICIAL As Long()
    Public MaxValor As Long
    Public UltimaPosicion As Long
    Public Lienzo As Graphics
    Public cAsignaciones As Integer
    Public cCondicionales As Integer


    Public Sub CambiarElementos(ByRef Vector As Object, Elemento1 As Long, Elemento2 As Long)
        Dim Aux As Object

        If Not IsArray(Vector) Then Exit Sub
        If Elemento1 > UBound(Vector) Or Elemento2 > UBound(Vector) Then Exit Sub
        If Elemento1 < LBound(Vector) Or Elemento2 < LBound(Vector) Then Exit Sub
        Aux = Vector(Elemento1)
        Vector(Elemento1) = Vector(Elemento2)
        Vector(Elemento2) = Aux
    End Sub

    Public Sub EventoDeMouseHover()
        If THREAD IsNot Nothing Then
            If THREAD.IsAlive Then
                Select Case THREAD.ThreadState
                    Case Threading.ThreadState.Running
                        Principal.Cursor = Cursors.Default
                    Case Threading.ThreadState.Suspended
                        Principal.Cursor = Cursors.Default
                    Case Else
                        Principal.Cursor = Cursors.Default
                End Select
            Else
                Principal.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Public Sub EventoDeMouseLeave()
        If THREAD IsNot Nothing Then
            If THREAD.IsAlive Then
                Select Case THREAD.ThreadState
                    Case Threading.ThreadState.Running
                        Principal.Cursor = Cursors.WaitCursor
                    Case Threading.ThreadState.Suspended
                        Principal.Cursor = Cursors.Default
                    Case Else
                        Principal.Cursor = Cursors.WaitCursor
                End Select
            Else
                Principal.Cursor = Cursors.Default
            End If
        End If
    End Sub

End Module
