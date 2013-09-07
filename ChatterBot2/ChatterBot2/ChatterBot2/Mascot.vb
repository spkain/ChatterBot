Public Class Mascot

    Const LEARN_MAX As Integer = 3
    Const DEFAULT_NAME As String = "名無しのごんべ"

    Public Enum CommandPtn As Integer
        LERNING = 0
        SAYCOUNT = 1
        ALLSAY = 2
        FORGET = 3
        SAY = 4
        ENDPROC = 5
    End Enum

    Private FName As String

    Property Name As String
        Get
            Return FName
        End Get
        Set(value As String)
            If value = Nothing Or Len(value) = 0 Then
                FName = DEFAULT_NAME
            Else
                FName = value
            End If
        End Set
    End Property

    Private WordList As New List(Of String)

    Public Sub New(ByVal aName As String)
        Name = aName
        MascotSay(String.Format("私,{0}っていうの　よろしくねっ！", Name))
    End Sub

    Public Sub GetCommand()
        Dim ptnNo As CommandPtn
        MascotSay("何するのー?")
        LineOut()
        Console.WriteLine("0: 学習してくれ 1:覚えた数は？ 2:今覚えたやつ言ってみて 3:忘れてくれっ 4:なんか言ってみて 5:帰って")
        Try
            Console.Write("選択肢＞ ")
            ptnNo = Int32.Parse(Console.ReadLine())
        Catch
            ptnNo = CommandPtn.LERNING
        End Try
        LineOut()
        Perform(ptnNo)

    End Sub

    Private Sub Perform(ByVal ptn As CommandPtn)
        Select Case ptn
            Case CommandPtn.SAYCOUNT
                SayLearningCount()
            Case CommandPtn.LERNING
                Learning()
            Case CommandPtn.ALLSAY
                AllSay()
            Case CommandPtn.FORGET
                Forget()
            Case CommandPtn.SAY
                Say()
            Case Else
                MascotSay("えー・・・、じゃあ行くね・・・、さよならーToTノシ")
                Environment.Exit(0)
        End Select
    End Sub

    Private Sub Forget()
        If WordList.Count = 0 Then
            MascotSay("1個もおぼえていないんですが")
            Exit Sub
        End If

        AllSay()

        MascotSay("何番を忘れるの？")
        Console.Write("選択肢> ")
        Dim selNo As Integer
        Try
            selNo = Int32.Parse(Console.ReadLine())
        Catch
            MascotSay("何かいけないこといれたでしょｗｗｗ")
            MascotSay("だーめ！だからねっ")
            Exit Sub
        End Try

        If selNo < 0 Or selNo > WordList.Count - 1 Then
            MascotSay("だーめ！　そんなのないよ！")
            Exit Sub
        End If

        Dim selWord As String = WordList.Item(selNo)

        WordList.RemoveAt(selNo)
        MascotSay(String.Format("{0}:{1}わすれたよっ", selNo, selWord))
        SayLearningCount()

    End Sub

    Private Sub Say()
        If WordList.Count = 0 Then
            MascotSay("1個もおぼえていないんですが")
            Exit Sub
        End If

        Dim sayNo As Integer
        Dim rnd As New Random
        Try
            sayNo = rnd.Next(WordList.Count)
        Catch
            sayNo = 0
        End Try
        MascotSay(WordList.Item(sayNo))

    End Sub

    Private Sub SayLearningCount()
        MascotSay(String.Format("今まで覚えた数は、{0}だよー", WordList.Count))
        If (WordList.Count = 0) Then
            MascotSay("１個もおぼえてないよーToT")
            MascotSay("教えて教えて！")
        End If

        Dim nowLearnCnt As Integer
        nowLearnCnt = LEARN_MAX - WordList.Count

        If (nowLearnCnt > 0) Then
            MascotSay(String.Format("後{0}個なら覚えられるよー", nowLearnCnt))
        End If

    End Sub

    Private Sub Learning()
        Dim LearnStr As String

        MascotSay("教えて教えて！")
        Console.Write("覚えさせる言葉を入れてください: ")
        ' TODO errch
        Try
            LearnStr = Console.ReadLine()
        Catch
            MascotSay("何かいけないこといれた？！ｗｗｗ")
            Exit Sub
        End Try

        If LearnStr = Nothing Or Len(LearnStr) = 0 Then
            MascotSay("えっ　何も教えてくれないの？ToT")
            Exit Sub
        End If

        If WordList.Count >= LEARN_MAX Then
            MascotSay("おぼえきれないよーToT")
            Exit Sub
        End If

        WordList.Add(LearnStr)
        MascotSay("ありがとねー。覚えたよー")

    End Sub

    Private Sub AllSay()
        Dim cnt As Integer = 0

        MascotSay("今まで覚えた内容を復唱するねっ")
        LineOut()
        If WordList.Count > 0 Then

            For Each learnStr As String In WordList
                MascotSay(String.Format("{0}に、「{1}」と～", cnt, learnStr))
                cnt = cnt + 1
            Next
            MascotSay("かなっ")
        Else
            MascotSay("１個も覚えてないよーToT")
        End If
        LineOut()

        Dim nowLearnCount As Integer
        nowLearnCount = LEARN_MAX - WordList.Count

        If nowLearnCount > 0 Then
            MascotSay(String.Format("後、{0}個なら覚えられるかもっ", nowLearnCount))
        Else
            MascotSay("もう、覚えられないよーToT")
        End If

        MascotSay("以上だよー")
    End Sub

    Private Sub MascotSay(ByVal mes As String)
        Console.WriteLine("{0}＞{1}", Name, mes)
    End Sub

    Private Sub LineOut()
        Console.WriteLine("==============================================")
    End Sub
End Class
