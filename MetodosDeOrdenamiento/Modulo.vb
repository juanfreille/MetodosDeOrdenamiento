Module Modulo

    Public Sub Repintar(VECTOR() As Long)
        Principal.THREAD.Join()
        VECTOR = VECTOR
        Principal.GraficarVector(Brushes.Green)
    End Sub

    Public Sub CambiarElementos(ByRef Vector As Object, Elemento1 As Long, Elemento2 As Long)
        Dim Temp As Object

        If Not IsArray(Vector) Then Exit Sub
        If Elemento1 > UBound(Vector) Or Elemento2 > UBound(Vector) Then Exit Sub
        If Elemento1 < LBound(Vector) Or Elemento2 < LBound(Vector) Then Exit Sub
        Temp = Vector(Elemento1)
        Vector(Elemento1) = Vector(Elemento2)
        Vector(Elemento2) = Temp
    End Sub



End Module
