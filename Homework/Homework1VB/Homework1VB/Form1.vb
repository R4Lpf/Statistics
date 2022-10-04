Imports System.Runtime.CompilerServices

Public Class Form1

    Dim count(5)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim max, min, a, s, d, f, g, h, arr(5)
        max = 6
        min = 1
        Randomize()
        For i = 0 To 5 Step 1
            arr(i) = Int((max - min + 1) * Rnd() + min)
        Next

        n1.Text = arr(0).ToString
        n2.Text = arr(1).ToString
        n3.Text = arr(2).ToString
        n4.Text = arr(3).ToString
        n5.Text = arr(4).ToString
        n6.Text = arr(5).ToString




        For i = 0 To 5 Step 1
            If arr(i) = 1 Then
                count(0) += 1
            ElseIf arr(i) = 2 Then
                count(1) += 1
            ElseIf arr(i) = 3 Then
                count(2) += 1
            ElseIf arr(i) = 4 Then
                count(3) += 1
            ElseIf arr(i) = 5 Then
                count(4) += 1
            ElseIf arr(i) = 6 Then
                count(5) += 1
            End If
        Next

        For Each series In Chart1.Series
            series.Points.Clear()
        Next



        Chart1.Series("Count").Points.AddXY("1", count(0))
        Chart1.Series("Count").Points.AddXY("2", count(1))
        Chart1.Series("Count").Points.AddXY("3", count(2))
        Chart1.Series("Count").Points.AddXY("4", count(3))
        Chart1.Series("Count").Points.AddXY("5", count(4))
        Chart1.Series("Count").Points.AddXY("6", count(5))











    End Sub

End Class
