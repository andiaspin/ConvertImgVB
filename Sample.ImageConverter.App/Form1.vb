Public Class Form1
    Dim SourceFilePath As String = ""
    Dim DestinationFilePath As String = ""
    Dim imgFormat As Imaging.ImageFormat
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbImageFormat.Items.Add("Select")
        cmbImageFormat.Items.Add("Bmp")
        cmbImageFormat.Items.Add("Jpeg")
        cmbImageFormat.Items.Add("Png")
        cmbImageFormat.Items.Add("Gif")
        cmbImageFormat.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileDlg As New OpenFileDialog
        If FileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            SourceFilePath = FileDlg.FileName
            TextBox1.Text = SourceFilePath
            PictureBox1.Image = Image.FromFile(SourceFilePath)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim folderDlg As New FolderBrowserDialog
        If folderDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            DestinationFilePath = folderDlg.SelectedPath
            TextBox2.Text = DestinationFilePath

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If SourceFilePath.Trim = "" Then
            MessageBox.Show("Please enter source file path")
            Return
        ElseIf DestinationFilePath.Trim = "" Then
            MessageBox.Show("Please enter destination file path")
            Return
        ElseIf TextBox3.Text.Trim = "" Then
            MessageBox.Show("Please enter file name")
            Return
        ElseIf cmbImageFormat.SelectedIndex = 0 Then
            MessageBox.Show("Please select image format")
            Return
        Else
            Dim LocatioFile As String = DestinationFilePath & "\" & TextBox3.Text
            Dim strformat As String = cmbImageFormat.Text
            Select Case strformat
                Case "Bmp"
                    imgFormat = Imaging.ImageFormat.Bmp
                    LocatioFile = LocatioFile & ".bmp"
                Case "Jpeg"
                    imgFormat = Imaging.ImageFormat.Jpeg
                    LocatioFile = LocatioFile & ".jpeg"
                Case "Png"
                    imgFormat = Imaging.ImageFormat.Png
                    LocatioFile = LocatioFile & ".png"
                Case "Gif"
                    imgFormat = Imaging.ImageFormat.Gif
                    LocatioFile = LocatioFile & ".gif"
            End Select
            Dim SourceImg As Image
            SourceImg = Image.FromFile(SourceFilePath)
            SourceImg.Save(LocatioFile, imgFormat)
            MessageBox.Show("Convert image successfully")
            PictureBox1.Image = Nothing
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            cmbImageFormat.SelectedIndex = 0
        End If
    End Sub
End Class