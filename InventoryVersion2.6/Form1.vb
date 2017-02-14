Public Class Form1

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        InventorySheet1BindingSource.MovePrevious()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        InventorySheet1BindingSource.AddNew()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        InventorySheet1BindingSource.MoveNext()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        On Error GoTo SaveErr
        InventorySheet1BindingSource.EndEdit()
        '   Table1TableAdapter.Update(Database1DataSet.Table1)
        MessageBox.Show("OK BOSS")
SaveErr:
        Exit Sub
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        InventorySheet1BindingSource.RemoveCurrent()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2point6.InventorySheet1' table. You can move, or remove it, as needed.
        Me.InventorySheet1TableAdapter.Fill(Me.Database1DataSet2point6.InventorySheet1)

    End Sub

    Private Sub btnSelfDestruct_Click(sender As Object, e As EventArgs) Handles btnSelfDestruct.Click
       
        Timer1.Enabled = True
        lblTimer.Visible = True
        lblTimer.BringToFront()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTimer.Text = lblTimer.Text - 1
        If lblTimer.Text = 0 Then
            Timer1.Enabled = False
            Dim Death = MessageBox.Show("YOU FOOL NOW WE'RE ALL GOING TO DIE", "BOOM", (MessageBoxButtons.OK))
            If Death = DialogResult.OK Then
                Timer2.Enabled = True
            End If
        End If
        If lblTimer.Text = 0 Then
            picBoom.BringToFront()
            picBoom.Visible = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Timer2.Enabled = True Then
            Timer2.Interval = Timer2.Interval + 100
        End If
        If Timer2.Interval = 1000 Then
            Me.Close()

        End If
    End Sub
End Class
