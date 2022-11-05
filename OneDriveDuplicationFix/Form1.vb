Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getFiles("D:\OneDrive\")
        MessageBox.Show("Done")
    End Sub

    Private Sub getFiles(p1 As String)
        For Each f As String In IO.Directory.GetFiles(p1)
            If f.Contains("-Physics-PC") Then
                RichTextBox1.Text &= f & vbCrLf


                If IO.File.Exists(f.Replace("-Physics-PC", "")) Then
                    If IO.File.GetLastWriteTime(f) > IO.File.GetLastWriteTime(f.Replace("-Physics-PC", "")) Then
                        IO.File.Delete(f.Replace("-Physics-PC", ""))
                        IO.File.Move(f, f.Replace("-Physics-PC", ""))
                    End If
                End If

                If IO.File.Exists(f.Replace("-Physics-PC-2", "")) Then
                    If IO.File.GetLastWriteTime(f) > IO.File.GetLastWriteTime(f.Replace("-Physics-PC-2", "")) Then
                        IO.File.Delete(f.Replace("-Physics-PC-2", ""))
                        IO.File.Move(f, f.Replace("-Physics-PC-2", ""))
                    End If
                End If
            End If
        Next
        For Each f As String In IO.Directory.GetDirectories(p1)
            getFiles(f)
        Next
    End Sub

End Class
