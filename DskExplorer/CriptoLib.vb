'<--->

' <Smart World Technologies> ---
' <All rigth reserverd 2016 CryptoLib V.1.0.0>
' <Created By Natanael Abad> ---

'</--->

Module CryptoLib


    Function EncriptIt(ByVal Linea As String) As String

        Dim CriptedLine As String

        Dim TestString As String = Linea


        Dim aString As String = Replace(TestString, " ", "-")

        Dim eString As String = Replace(aString, "A", "Λ")

        Dim iString As String = Replace(eString, "B", "ͽ")

        Dim oString As String = Replace(iString, "C", "┐")

        Dim uString As String = Replace(oString, "D", "┴")

        Dim kString As String = Replace(uString, "E", "╚")

        Dim UUString As String = Replace(kString, "F", "╩")

        Dim gString As String = Replace(UUString, "G", "{")

        Dim tString As String = Replace(gString, "H", "]")

        Dim zString As String = Replace(tString, "I", "Î")

        Dim dString As String = Replace(zString, "J", "ĩ")

        Dim sString As String = Replace(dString, "K", "͡ ")

        Dim nString As String = Replace(sString, "L", "↑")

        Dim lString As String = Replace(nString, "", "")

        Dim vString As String = Replace(lString, "M", "→")

        Dim fString As String = Replace(vString, "N", "!")

        Dim mString As String = Replace(fString, "Ñ", "¿")

        Dim bString As String = Replace(mString, "O", "ʎ")

        Dim iiString As String = Replace(bString, "P", ")")

        Dim llString As String = Replace(iiString, "Q", "Ώ")

        Dim jjString As String = Replace(llString, "S", "Ƶ")

        Dim bbString As String = Replace(jjString, "T", "Ɂ")

        Dim qqString As String = Replace(bbString, "U", "Ơ")

        Dim iiiString As String = Replace(qqString, "V", "•")

        Dim iuString As String = Replace(iiiString, "W", "Ǭ")

        Dim ioString As String = Replace(iuString, "Y", "«")

        Dim ipString As String = Replace(ioString, "X", "Ȳ")

        Dim ifString As String = Replace(ipString, "Z", "\")

        '________________________________________________________________________

        Dim eeString As String = Replace(ifString, "a", "^")

        Dim ikString As String = Replace(eeString, "b", "ͼ")

        Dim obString As String = Replace(ikString, "c", "└")

        Dim ujString As String = Replace(obString, "d", "┬")

        Dim kjString As String = Replace(ujString, "e", "╔")

        Dim UUjString As String = Replace(kjString, "f", "╦")

        Dim gjString As String = Replace(UUjString, "g", "}")

        Dim tjString As String = Replace(gjString, "h", "[")

        Dim zjString As String = Replace(tjString, "i", "'")

        Dim djString As String = Replace(zjString, "j", "ī")

        Dim sjString As String = Replace(djString, "k", " ͜")

        Dim njString As String = Replace(sjString, "l", "↓")

        Dim lqString As String = Replace(njString, "", "")

        Dim vqString As String = Replace(lqString, "m", "←")

        Dim fqString As String = Replace(vqString, "n", "¡")

        Dim mqString As String = Replace(fqString, "ñ", "?")

        Dim bqString As String = Replace(mqString, "o", "ʏ")

        Dim iiqString As String = Replace(bqString, "p", "(")

        Dim llqString As String = Replace(iiqString, "q", "Ø")

        Dim jjqString As String = Replace(llqString, "s", "ƶ")

        Dim bbqString As String = Replace(jjqString, "t", "ɂ")

        Dim qqeString As String = Replace(bbqString, "u", "ơ")

        Dim iiioString As String = Replace(qqeString, "v", "°")

        Dim iueString As String = Replace(iiioString, "w", "ǭ")

        Dim ioeString As String = Replace(iueString, "y", "»")

        Dim ipeString As String = Replace(ioeString, "x", "ȳ")

        Dim ifeString As String = Replace(ipeString, "z", "/")


        Dim n1 As String = Replace(ipeString, "1", ".")

        Dim n2 As String = Replace(n1, "2", "&")

        Dim n3 As String = Replace(n2, "3", "ª")

        Dim n4 As String = Replace(n3, "4", "$")

        Dim n5 As String = Replace(n4, "5", "♫")

        Dim n6 As String = Replace(n5, "6", "ç")

        Dim n7 As String = Replace(n6, "7", "¥")

        Dim n8 As String = Replace(n7, "8", "☼")

        Dim n9 As String = Replace(n8, "9", "Ψ")

        Dim n0 As String = Replace(n9, "0", "%")


        CriptedLine = n0


        Return CriptedLine

    End Function


    Function DesEncriptIt(ByVal Linea As String) As String

        Dim unCriptedLine As String

        Dim TestString As String = Linea


        Dim aString As String = Replace(TestString, "-", " ")

        Dim eString As String = Replace(aString, "Λ", "A")

        Dim iString As String = Replace(eString, "ͽ", "B")

        Dim oString As String = Replace(iString, "┐", "C")

        Dim uString As String = Replace(oString, "┴", "D")

        Dim kString As String = Replace(uString, "╚", "E")

        Dim UUString As String = Replace(kString, "╩", "F")

        Dim gString As String = Replace(UUString, "{", "G")

        Dim tString As String = Replace(gString, "]", "H")

        Dim zString As String = Replace(tString, "Î", "I")

        Dim dString As String = Replace(zString, "ĩ", "J")

        Dim sString As String = Replace(dString, "͡ ", "K")

        Dim nString As String = Replace(sString, "↑", "L")

        Dim lString As String = Replace(nString, "", "")

        Dim vString As String = Replace(lString, "→", "M")

        Dim fString As String = Replace(vString, "!", "N")

        Dim mString As String = Replace(fString, "¿", "Ñ")

        Dim bString As String = Replace(mString, "ʎ", "O")

        Dim iiString As String = Replace(bString, ")", "P")

        Dim llString As String = Replace(iiString, "Ώ", "Q")

        Dim jjString As String = Replace(llString, "Ƶ", "S")

        Dim bbString As String = Replace(jjString, "Ɂ", "T")

        Dim qqString As String = Replace(bbString, "Ơ", "U")

        Dim iiiString As String = Replace(qqString, "•", "V")

        Dim iuString As String = Replace(iiiString, "Ǭ", "W")

        Dim ioString As String = Replace(iuString, "«", "Y")

        Dim ipString As String = Replace(ioString, "Ȳ", "X")

        Dim ifString As String = Replace(ipString, "\", "Z")

        '________________________________________________________________________

        Dim eeString As String = Replace(ifString, "^", "a")

        Dim ikString As String = Replace(eeString, "ͼ", "b")

        Dim obString As String = Replace(ikString, "└", "c")

        Dim ujString As String = Replace(obString, "┬", "d")

        Dim kjString As String = Replace(ujString, "╔", "e")

        Dim UUjString As String = Replace(kjString, "╦", "f")

        Dim gjString As String = Replace(UUjString, "}", "g")

        Dim tjString As String = Replace(gjString, "[", "h")

        Dim zjString As String = Replace(tjString, "'", "i")

        Dim djString As String = Replace(zjString, "ī", "j")

        Dim sjString As String = Replace(djString, " ͜", "k")

        Dim njString As String = Replace(sjString, "↓", "l")

        Dim lqString As String = Replace(njString, "", "")

        Dim vqString As String = Replace(lqString, "←", "m")

        Dim fqString As String = Replace(vqString, "¡", "n")

        Dim mqString As String = Replace(fqString, "?", "ñ")

        Dim bqString As String = Replace(mqString, "ʏ", "o")

        Dim iiqString As String = Replace(bqString, "(", "p")

        Dim llqString As String = Replace(iiqString, "Ø", "q")

        Dim jjqString As String = Replace(llqString, "ƶ", "s")

        Dim bbqString As String = Replace(jjqString, "ɂ", "t")

        Dim qqeString As String = Replace(bbqString, "ơ", "u")

        Dim iiioString As String = Replace(qqeString, "°", "v")

        Dim iueString As String = Replace(iiioString, "ǭ", "w")

        Dim ioeString As String = Replace(iueString, "»", "y")

        Dim ipeString As String = Replace(ioeString, "ȳ", "x")

        Dim ifeString As String = Replace(ipeString, "/", "z")


        Dim n1 As String = Replace(ipeString, ".", "1")

        Dim n2 As String = Replace(n1, "&", "2")

        Dim n3 As String = Replace(n2, "ª", "3")

        Dim n4 As String = Replace(n3, "$", "4")

        Dim n5 As String = Replace(n4, "♫", "5")

        Dim n6 As String = Replace(n5, "ç", "6")

        Dim n7 As String = Replace(n6, "¥", "7")

        Dim n8 As String = Replace(n7, "☼", "8")

        Dim n9 As String = Replace(n8, "Ψ", "9")

        Dim n0 As String = Replace(n9, "%", "0")


        unCriptedLine = n0


        Return unCriptedLine

    End Function

End Module
