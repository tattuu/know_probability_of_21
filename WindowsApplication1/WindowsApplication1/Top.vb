Public Class Top ' ファイル名Top.vb,識別コードTop
    Private EndOrClose As Boolean ' ×ボタンで閉じているか、それ以外で閉じているかを判定するのに用いるEndOrCloseを論理型で宣言

    Private Sub Top_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load ' Topフォームが読み込まれた時に行うイベントプロシージャ
        EndOrClose = True 'True(1)を代入
    End Sub
    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing ' フォームを閉じるイベントが発生した時に発生するイベントプロシージャ
        If EndOrClose = False Then ' EndOrCloseがFalse(0)かどうか
            Dim f1 As New Main ' Mainフォームのインスタンスを生成
            f1.Show() ' Mainフォームを表示
            My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
        Else
            Dim Answer As MsgBoxResult ' MsgBoxの結果を保存しておくための変数Answerを宣言
            Answer = MsgBox("終了しますか？", MsgBoxStyle.YesNo, "確認") ' MsgBoxの表示と、YesNoの選んだ値をAnswerに代入
            If (Answer = vbNo) Then ' Noの時
                e.Cancel = True ' 閉じる処理をキャンセル
            End If
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click ' PictureBox1がクリックされた時に発生するイベントプロシージャ
        EndOrClose = False ' EndOrCloseにFalseを代入
        Me.Close() ' 今開いているフォームを閉じる
    End Sub
End Class