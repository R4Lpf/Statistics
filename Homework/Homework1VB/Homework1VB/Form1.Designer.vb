<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.n1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.n2 = New System.Windows.Forms.Label()
        Me.n3 = New System.Windows.Forms.Label()
        Me.n4 = New System.Windows.Forms.Label()
        Me.n5 = New System.Windows.Forms.Label()
        Me.n6 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'n1
        '
        Me.n1.AutoSize = True
        Me.n1.Location = New System.Drawing.Point(145, 107)
        Me.n1.Name = "n1"
        Me.n1.Size = New System.Drawing.Size(13, 13)
        Me.n1.TabIndex = 0
        Me.n1.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(114, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'n2
        '
        Me.n2.AutoSize = True
        Me.n2.Location = New System.Drawing.Point(145, 134)
        Me.n2.Name = "n2"
        Me.n2.Size = New System.Drawing.Size(13, 13)
        Me.n2.TabIndex = 3
        Me.n2.Text = "0"
        '
        'n3
        '
        Me.n3.AutoSize = True
        Me.n3.Location = New System.Drawing.Point(145, 161)
        Me.n3.Name = "n3"
        Me.n3.Size = New System.Drawing.Size(13, 13)
        Me.n3.TabIndex = 4
        Me.n3.Text = "0"
        '
        'n4
        '
        Me.n4.AutoSize = True
        Me.n4.Location = New System.Drawing.Point(145, 188)
        Me.n4.Name = "n4"
        Me.n4.Size = New System.Drawing.Size(13, 13)
        Me.n4.TabIndex = 5
        Me.n4.Text = "0"
        '
        'n5
        '
        Me.n5.AutoSize = True
        Me.n5.Location = New System.Drawing.Point(145, 214)
        Me.n5.Name = "n5"
        Me.n5.Size = New System.Drawing.Size(13, 13)
        Me.n5.TabIndex = 6
        Me.n5.Text = "0"
        '
        'n6
        '
        Me.n6.AutoSize = True
        Me.n6.Location = New System.Drawing.Point(145, 241)
        Me.n6.Name = "n6"
        Me.n6.Size = New System.Drawing.Size(13, 13)
        Me.n6.TabIndex = 7
        Me.n6.Text = "0"
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(294, 60)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar
        Series1.Legend = "Legend1"
        Series1.Name = "Count"
        Series1.YValuesPerPoint = 4
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(427, 324)
        Me.Chart1.TabIndex = 8
        Me.Chart1.Text = "Chart1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(98, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Random Numbers"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.n6)
        Me.Controls.Add(Me.n5)
        Me.Controls.Add(Me.n4)
        Me.Controls.Add(Me.n3)
        Me.Controls.Add(Me.n2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.n1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents n1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents n2 As Label
    Friend WithEvents n3 As Label
    Friend WithEvents n4 As Label
    Friend WithEvents n5 As Label
    Friend WithEvents n6 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label1 As Label
End Class
