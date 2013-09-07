Module ChatModule

    Sub Main()
        Dim chara As New Charactor(Charactor.Feel.Normal, "hanako")

        chara.SayHello()
        Do While True
            chara.ReadText()
            chara.Say()
            chara.Performed()
        Loop

    End Sub

End Module
