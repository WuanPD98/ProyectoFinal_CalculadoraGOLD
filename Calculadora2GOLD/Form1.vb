Imports System.IO

Public Class Form1
    Private Sub btnOperar_Click(sender As Object, e As EventArgs) Handles btnOperar.Click
        MyParser.Setup()

        If (MyParser.Parse(New StringReader(Me.rtxtOperacion.Text))) Then
            Dim res As Integer
            res = Action(MyParser.Root, Nothing)
            Me.rtxtResultado.Text = res
        Else
            MsgBox("Ha sucedido un error")
        End If
    End Sub

    Private Function Action(ByVal Root As GOLD.Reduction, ByVal Obj As Object) As Object
        Dim objeto As Object = Nothing

        Select Case Root.Parent.Text
            Case "<E> ::= <E> '+' <T>"
                Dim val1 As Integer
                Dim val2 As Integer
                Dim res As Integer

                objeto = Action(Root(0).Data, Nothing)
                val1 = Integer.Parse(objeto.ToString)

                objeto = Action(Root(2).Data, Nothing)
                val2 = Integer.Parse(objeto.ToString)

                res = val1 + val2

                objeto = res

            Case "<E> ::= <T>"
                objeto = Action(Root(0).Data, Nothing)

            Case "<T> ::= <T> '*' <F>"
                Dim val1 As Integer
                Dim val2 As Integer
                Dim res As Integer

                objeto = Action(Root(0).Data, Nothing)
                val1 = Integer.Parse(objeto.ToString)

                objeto = Action(Root(2).Data, Nothing)
                val2 = Integer.Parse(objeto.ToString)

                res = val1 * val2

                objeto = res

            Case "<T> ::= <F>"
                objeto = Action(Root(0).Data, Nothing)

            Case "<F> ::= NUMERO"
                objeto = Root(0).Data



        End Select
        Return objeto
    End Function
End Class
