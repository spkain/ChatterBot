Imports System.Environment

Public Class Charactor
    Dim FFeelStatus As Integer = 0
    Private chara_name As String = "名無し"

    Public Enum Feel As Integer
        VeryBad = 0
        Bad = 1
        Normal = 2
        Good = 3
        VeryGood = 4
        Finish = 5
    End Enum

    Property CharaName As String
        Get
            Return chara_name
        End Get
        Set(value As String)
            If value = Nothing Or Len(value) = 0 Then
                chara_name = "名無し"
            Else
                chara_name = value
            End If

        End Set
    End Property

    Property FeelStatus As Integer
        Get
            Return FFeelStatus
        End Get
        Set(value As Integer)
            If value < 0 Then
                FFeelStatus = 0
            End If
            If value > 5 Then
                FFeelStatus = 5
            End If
            FFeelStatus = value
        End Set
    End Property

    Sub New(ByVal aFeel As Feel, ByVal aCharaName As String)
        FeelStatus = aFeel
        CharaName = aCharaName

        Console.WriteLine("{0}＞私は、{0}です。", CharaName)

    End Sub

    Sub SayHello()
        Dim hour As Integer = Now.Hour
        Dim sayHello As String
        Dim name As String
        name = Console.ReadLine()

        Console.Write("{0}＞{1}さん", CharaName, name)

        Select Case hour
            Case 0 To 5
                sayHello = "こんばんはー"
            Case 6 To 11
                sayHello = "おはようー"
            Case 12 To 18
                sayHello = "こんにちはー"
            Case 19 To 23
                sayHello = "こんばんはー"
            Case Else
                sayHello = "こんにちは"
        End Select
        Console.WriteLine(sayHello)
    End Sub

    Sub ReadText()
        Dim aChatNo As Integer
        Console.WriteLine("--------------------------------")
        Console.WriteLine("0: ばーか 1:今日は髪乱れてるよ 2:よっす 3:昨日なんかいいことあった？ 4:今日はきれいだよ 5:終わってくれ")
        Console.Write("<会話選択肢> ")

        Try
            aChatNo = Int32.Parse(Console.ReadLine)
        Catch
            aChatNo = 2
        End Try
        Console.WriteLine("--------------------------------")
        FeelStatus = aChatNo
    End Sub

    Sub Say()
        Dim Say As String
        Console.Write("{0}＞", CharaName)

        Select Case FeelStatus
            Case Feel.VeryBad
                Say = "機嫌悪いんだけどー"
            Case Feel.Bad
                Say = "うん・・・"
            Case Feel.Normal
                Say = "ふつうっす"
            Case Feel.Good
                Say = "げんきー？"
            Case Feel.VeryGood
                Say = "サイコー"
            Case Feel.Finish
                Say = "人生に疲れました・・・"
            Case Else
                Say = "げんきー？"
        End Select
        Console.WriteLine(Say)
    End Sub

    Sub Performed()
        Console.WriteLine("今歩いているの")
        If FeelStatus = Feel.Finish Then
            Console.WriteLine("そろそろ行くね　またねー")
            Environment.Exit(0)
        End If
    End Sub

End Class
