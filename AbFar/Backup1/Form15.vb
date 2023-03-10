Imports System.IO
Public Class Form15
    Dim g As Graphics
    Dim startLocation As Point
    Dim endLocation As Point
    Dim TempLocation As New Point(-1, -1)
    Dim TempLocation2 As New Point(-1, -1)
    Dim NumberOfAngle As Integer = 0
    Dim drawing As Boolean = False
    Dim CurrentColor As Color = Color.Blue
    Dim CurrentColor2 As Color = Color.LightSkyBlue
    Dim LastImage As New Bitmap(665, 720)
    Dim M1 As New Bitmap(501, 501)
    Dim M2 As New Bitmap(501, 501)
    Dim M3 As New Bitmap(501, 501)
    Dim M4 As New Bitmap(501, 501)
    Public address As String
    Dim PenWidth As Single = 1.0F
    Dim PenPoint As Pen
    Dim SavedFileAddress As String = ""

    Dim CurrentFont As Font

    Public BL As Boolean = False
    Public S As Boolean = False
    Public X As Integer
    Public Y As Integer

    'پر کردن يک ناحيه بسته با يک رنگ دلخواه با دريافت مختصات 
    'يک نقطه از طريق
    'X,Y
    Function FillRegion(ByVal X As Integer, ByVal Y As Integer, ByVal FillCol As Color) As Boolean

        'بايد دقت شود که مختصات درخواستی مقادير درستی را داشته باشند
        'یعنی حتماً در اندازه و مختصات تصوير صدق کند
        If X < 0 Or X > LastImage.Width Or Y < 0 Or Y > LastImage.Height Then
            Return False

        End If

        MessageLabel.Text = "لطفاً صبر کنيد, اين عمليات ممکن است مدتی به درازا بیانجامد"
        Application.DoEvents()

        'يک پشته از تمام نقاطی که در محيط بسته قرار مي گيرند است
        Dim points As Stack = New Stack
        'در ابتدا مختصات نقطه اوليه را در پشته پوش می کنیم
        points.Push(New Point(X, Y))

        'رنگ ناحيه ای که بايد پر شود بايد با رنگه پيکسلی که مختصات آن با
        'X,Y
        'اعلام شده يکی باشدکه اين رنگ با دستور زطر مشخص می شود
        Dim Pointcolor As Color = LastImage.GetPixel(X, Y)


        Do
            Dim p As Point = CType(points.Pop(), Point)

            'رنگ کردن پيکسلی که در ناحطه بسته قرار دارد با رنگ مورد نظر
            LastImage.SetPixel(p.X, p.Y, FillCol)

            'آيا پيکسل بالای پيکسلی که موقعيت آن با مقادير
            'X,Y
            'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
            'Fill
            'قرار گيرد و به پشته اضافه می گردد
            If UpPixelHaseSameColor(p.X, p.Y, Pointcolor) Then
                points.Push(New Point(p.X, p.Y - 1))
            End If

            'آيا پيکسل پايين پيکسلی که موقعيت آن با مقادير
            'X,Y
            'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
            'Fill
            'قرار گيرد و به پشته اضافه می گردد
            If DownPixelHaseSameColor(p.X, p.Y, Pointcolor) Then
                points.Push(New Point(p.X, p.Y + 1))
            End If


            'آيا پيکسل راست پيکسلی که موقعيت آن با مقادير
            'X,Y
            'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
            'Fill
            'قرار گيرد و به پشته اضافه می گردد
            If RightPixelHaseSameColor(p.X, p.Y, Pointcolor) Then
                points.Push(New Point(p.X + 1, p.Y))
            End If

            'آيا پيکسل چپ پيکسلی که موقعيت آن با مقادير
            'X,Y
            'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
            'Fill
            'قرار گيرد و به پشته اضافه می گردد
            If LeftPixelHaseSameColor(p.X, p.Y, Pointcolor) Then
                points.Push(New Point(p.X - 1, p.Y))
            End If

            'تا زمانی رنگ آميزی را ادامه می دهيم که ديگر هيچ نقطه ای در پشته ای که نگه دارنده ی
            'نقاط صدق کننده در محيط بسته قرار است وجود نداشته باشد
        Loop While points.Count > 0

        MessageLabel.Text = "-----"
        Return True

    End Function

    'آيا پيکسل بالای پيکسلی که موقعيت آن با مقادير
    'X,Y
    'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
    'Fill
    'قرار گيرد
    Function UpPixelHaseSameColor(ByVal X As Integer, ByVal Y As Integer, ByVal Col As Color) As Boolean
        Dim result As Boolean = False
        If (Y > 0) Then
            If (LastImage.GetPixel(X, Y - 1) = Col) Then
                result = True
            End If

        End If
        Return result

    End Function

    'آيا پيکسل پايين پيکسلی که موقعيت آن با مقادير
    'X,Y
    'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
    'Fill
    'قرار گيرد
    Function DownPixelHaseSameColor(ByVal X As Integer, ByVal Y As Integer, ByVal Col As Color) As Boolean
        Dim result As Boolean = False
        If (Y < LastImage.Height - 1) Then
            If (LastImage.GetPixel(X, Y + 1) = Col) Then
                result = True
            End If

        End If
        Return result

    End Function

    'آيا پيکسل راست پيکسلی که موقعيت آن با مقادير
    'X,Y
    'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
    'Fill
    'قرار گيرد
    Function RightPixelHaseSameColor(ByVal X As Integer, ByVal Y As Integer, ByVal Col As Color) As Boolean
        Dim result As Boolean = False
        If (X < LastImage.Width - 1) Then
            If (LastImage.GetPixel(X + 1, Y) = Col) Then
                result = True
            End If

        End If

        Return result

    End Function

    'آيا پيکسل چپ پيکسلی که موقعيت آن با مقادير
    'X,Y
    'پاس شده است با آن همرنگ است يا نه اگر بود یعنی اينکه می تواند در محدوده 
    'Fill
    'قرار گيرد
    Function LeftPixelHaseSameColor(ByVal X As Integer, ByVal Y As Integer, ByVal Col As Color) As Boolean

        Dim result As Boolean = False
        If (X > 0) Then
            If (LastImage.GetPixel(X - 1, Y) = Col) Then
                result = True
            End If
        End If


        Return result

    End Function

    'به روز رسانی تصوير 
    'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
    Sub UpdateImage()
        'تمامی دستورات روی متغيير 
        'LastImage
        'که از نوع 
        'Bitmap
        'است اعمال می شود در نهايت برای مشاهده نتيجه بايد آن را در يک کنترل که توانايي 
        'نشان دادن تصوير را دارد داد
        'که کنترل هايي از نوع
        'PictureBox
        'اين توانايي را دارند
        'متغيير 
        'PictureBox1
        'نيز از اين نوع است
        'خصوصيت 
        'Image
        'مقدار
        'LastImage
        'را به دريافت کرده و در خروجی تصوير معادل را رسم می نمايد

        g = Graphics.FromImage(LastImage)

        Me.PictureBox1.Image = LastImage

    End Sub


    'ساختن قلم ترسيم به ضخامت و رنگ مورد نظر
    Sub ReloadPen(ByVal PenWd As Single, ByVal CurColor As Color)
        PenPoint = New Pen(CurColor, PenWd)

    End Sub

    'وقتی يکي از کليدهای ماموس روی 
    'PictureBox1
    'پايين می رود
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown

        'تشخيص داده می شود که الان کليد سمت چپ ماموس فشرده شده است
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If drawing = False Then
                'ذخيره موقعيت ابتدا
                startLocation = e.Location

                'صدور اجازه ی رسم يک ترسيم
                drawing = True

                'رسم چند ضلعی
                If MultiAngleRadioButton.Checked Then
                    'مکان شروع چند ضلعی را ذخيره می کند تا وقتی با کليک راست 
                    'انتهای پایان ترسیم چند ضلعی مشخص شد از اخرين نقطه به نقطه ی ابتدايي
                    'ضلع پایانی نيز رسم شود
                    If TempLocation.X = -1 Then
                        TempLocation = startLocation
                        TempLocation2 = startLocation
                    End If

                    'نرسيم يکی  از اضلاع  ما بين دو راس مشخص شده
                    endLocation = e.Location
                    g.DrawLine(PenPoint, TempLocation, endLocation)
                    TempLocation = endLocation


                    'رسم مثلث
                ElseIf TriangleRadioButton.Checked Then
                    'مکان شروع مثلث را ذخيره می کند تا وقتی با فشردن 3 بار ماموس در نقطه متمايز 
                    'سه راس مثلث مشخص شد ضلع سوم بطور خودکار رسم شود
                    If TempLocation.X = -1 Then
                        TempLocation = startLocation
                        TempLocation2 = startLocation
                    End If

                    'بررسی می کند که چند بار کليد سمت چپ برای ترسيم مثلث فشرده شده است
                    If NumberOfAngle <= 2 Then

                        'نرسيم يکی  از اضلاع مثلث ما بين دو راس مشخص شده
                        endLocation = e.Location
                        g.DrawLine(PenPoint, TempLocation, endLocation)
                        TempLocation = endLocation

                        'ترسيم آخرين ضلع بطور خودکار
                        'چون راس اول و سوم مشخص است 
                        'مختصات راس اول در متغيير
                        'TempLocation2
                        'ذخيره شده و مختصات راس سوم در متغيير
                        'TempLocation

                        If NumberOfAngle = 2 Then
                            g.DrawLine(PenPoint, TempLocation, TempLocation2)
                            TempLocation = New Point(-1, -1)
                            NumberOfAngle = 0
                        Else
                            NumberOfAngle += 1
                        End If


                    End If


                End If


            End If


            'تشخيص داده می شود که الان کليد سمت راست ماموس فشرده شده است
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            'انتهای پایان ترسیم چند ضلعی
            If MultiAngleRadioButton.Checked Then
                If TempLocation.X <> -1 Then
                    endLocation = e.Location
                    g.DrawLine(PenPoint, TempLocation, TempLocation2)
                    'با ست کردن اين مقدار به متغيير می توانيم دوباره چند ضلعی مجزای ديگری را ترسيم کنيم
                    'در طورتيکه اطن کار صورت نگيرد چند ضلعی بعدی به چند ضلعی قبلی متصل می شود
                    TempLocation = New Point(-1, -1)
                End If

            End If




        End If

    End Sub


    'وقتی  ماموس روی 
    'PictureBox1
    'حرکت می کند
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        'اگر اجازه ی رسم صادر شده بود نگاه می توانيم ترسطم کنيم
        If drawing = True Then

            'ترسيم خط
            If LineRadioButton.Checked Then
                'رسم خط بين دو نقطه موقعيت فعلی ماموس و موقعيت ابتدايي 
                g.DrawLine(PenPoint, startLocation.X, startLocation.Y, e.X, e.Y)
                'برای اينکه خط ممتد به نظر آيد هر بار بعد از رسم خط نقطه ابتدايي را با نقطه انتهايي
                'خط قبلی ست می کنيم تا ابتدای خط جديد روی انتهای خط قبلی قرار گيرد
                startLocation = e.Location

                'به روز رسانی تصوير 
                'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
                UpdateImage()


                'پاک کن
            ElseIf EraserRadioButton.Checked Then
                'در واقع همان ترسيم خط است فقط با اين بار به جای 
                ' رنگی قلم برای ترسيم از يک
                'رنگ ديگر استفاده می کنيم و آن هم رنگ زمينه يعنی رنگ سفيد است

                Dim p As New Pen(Color.White, PenWidth)

                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود
                'رسم خط بين دو نقطه موقعيت فعلی ماموس و موقعيت ابتدايي 
                g.DrawLine(p, startLocation.X, startLocation.Y, e.X, e.Y)
                'برای اينکه خط ممتد به نظر آيد هر بار بعد از رسم خط نقطه ابتدايي را با نقطه انتهايي
                'خط قبلی ست می کنيم تا ابتدای خط جديد روی انتهای خط قبلی قرار گيرد
                startLocation = e.Location

                'به روز رسانی تصوير 
                'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
                UpdateImage()

            End If

        End If
    End Sub


    'وقتی يکي از کليدهایی که  ماموس روی 
    'PictureBox1
    'پايين رفته بود رها می شود
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp

        'اگر اجازه ی رسم صادر شده بود نگاه می توانيم ترسطم کنيم
        If drawing Then

            'ترسيم چهار ضلعی
            If RectangleRadioButton.Checked Then
                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود

                'موقعيت انتهای چهارضلعی
                endLocation = e.Location

                'با استفاده از موقعيت ابتدا و انتها طول و عرض چهار ضلعی را بدست می آوريم
                Dim s As Point

                'محاسبه طول
                s.X = endLocation.X - startLocation.X
                'به دليل اينکه طول نمی تواند منفی باشد
                'موقعيت 
                'X
                'ابتدا و انتها را جابجا می کنيم
                'اگر طول بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن طول ,طول در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'X
                'نقاط ابتدا و انتها جابجا می شود
                If s.X < 0 Then
                    startLocation.X = endLocation.X

                End If

                'محاسبه عرض
                s.Y = endLocation.Y - startLocation.Y

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.Y < 0 Then
                    startLocation.Y = endLocation.Y

                End If

                'به دليل اينکه طول نمی تواند منفی باشد
                s.X = Math.Abs(s.X)
                'به دليل اينکه عرض نمی تواند منفی باشد
                s.Y = Math.Abs(s.Y)

                'رسم چهار ضلعی
                g.DrawRectangle(PenPoint, New Rectangle(startLocation, s))


                'ترسيم چهار ضلعی از طيف رنگی
            ElseIf GradientRectAngleRadioButton.Checked Then
                'در واقع همان ترسيم چهارضلعی است فقط با اين بار به جای 
                'Pen
                'برای ترسيم از يک
                'Brush
                'استفاده می شود که توانايي ايجاد طيف رنگی ما بين چند رنگ را دارد

                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود

                'موقعيت انتهای چهارضلعی
                endLocation = e.Location

                'با استفاده از موقعيت ابتدا و انتها طول و عرض چهار ضلعی را بدست می آوريم
                Dim s As Point

                'محاسبه طول
                s.X = endLocation.X - startLocation.X
                'به دليل اينکه طول نمی تواند منفی باشد
                'موقعيت 
                'X
                'ابتدا و انتها را جابجا می کنيم
                'اگر طول بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن طول ,طول در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'X
                'نقاط ابتدا و انتها جابجا می شود
                If s.X < 0 Then
                    startLocation.X = endLocation.X
                ElseIf s.X = 0 Then
                    s.X = 1
                End If

                'محاسبه عرض
                s.Y = endLocation.Y - startLocation.Y

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.Y < 0 Then
                    startLocation.Y = endLocation.Y
                ElseIf s.Y = 0 Then
                    s.Y = 1
                End If

                'به دليل اينکه طول نمی تواند منفی باشد
                s.X = Math.Abs(s.X)
                'به دليل اينکه عرض نمی تواند منفی باشد
                s.Y = Math.Abs(s.Y)


                'ايجاد 
                'Brush 
                'از دو رنگ که رنگ ابتدا رنگ جاری و رنگ دوم از 
                'Color2
                'گرفته می شود
                Dim b As Brush
                b = New Drawing2D.LinearGradientBrush(New Rectangle(startLocation, s), CurrentColor, CurrentColor2, Drawing2D.LinearGradientMode.BackwardDiagonal)
                'رسم چهار ضلعی طيف رنگی
                g.FillRectangle(b, New Rectangle(startLocation, s))



                'رسم دايره
            ElseIf CircleRadioButton.Checked Then
                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود


                'در واقع با محصور کردن دايره در يک چهارضلعی ,دايره را رسم می کنيم
                'عمليات زير در واقع همانند بدست آوردن نقطه ابتدايي و انتهايي و طول و عرض
                'چهار ضلعی است اما با اين تفاوت که در نهايت به در نظر گرفتن ضلع بزرگتر چهار ضلعی
                'به عنوان قطر اصلی دايره , در نهايت يک دايره محيطی رسم می شود


                'موقعيت انتهای چهارضلعی
                endLocation = e.Location

                'با استفاده از موقعيت ابتدا و انتها طول و عرض چهار ضلعی را بدست می آوريم
                Dim s As Point

                'محاسبه طول
                s.X = endLocation.X - startLocation.X

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.X < 0 Then
                    startLocation.X = endLocation.X

                End If


                'محاسبه عرض
                s.Y = endLocation.Y - startLocation.Y

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.Y < 0 Then
                    startLocation.Y = endLocation.Y

                End If


                'به دليل اينکه طول نمی تواند منفی باشد
                s.X = Math.Abs(s.X)
                'به دليل اينکه عرض نمی تواند منفی باشد
                s.Y = Math.Abs(s.Y)


                'قطر دايره با طول ضلع بزرگتر چهارضلعی ست می کند
                If s.X > s.Y Then
                    s.Y = s.X
                Else
                    s.X = s.Y
                End If

                'رسم دايره
                g.DrawEllipse(PenPoint, New Rectangle(startLocation, s))


                'رسم نيم دايره
            ElseIf ArcRadioButton.Checked Then


                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود


                'در واقع با محصور کردن دايره در يک چهارضلعی ,دايره را رسم می کنيم
                'عمليات زير در واقع همانند بدست آوردن نقطه ابتدايي و انتهايي و طول و عرض
                'چهار ضلعی است اما با اين تفاوت که در نهايت به در نظر گرفتن ضلع بزرگتر چهار ضلعی
                'به عنوان قطر اصلی دايره , در نهايت يک دايره محيطی رسم می شود
                'سپس به محدود کردن رسم دايره بين 0 درجه و -180 درجه به دليل اينکه جهت ترسيم موافق عقربه های
                'ساعت است پس بايد جهت ترسيم را به قرار دادن درجه ی انتهايي با مقدار -180 آن را پادساعتگرد کنيم
                'نيم دايره ترسيم می شود


                'موقعيت انتهای چهارضلعی
                endLocation = e.Location

                'با استفاده از موقعيت ابتدا و انتها طول و عرض چهار ضلعی را بدست می آوريم
                Dim s As Point

                'محاسبه طول
                s.X = endLocation.X - startLocation.X

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.X < 0 Then
                    startLocation.X = endLocation.X

                End If

                'محاسبه عرض
                s.Y = endLocation.Y - startLocation.Y

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.Y < 0 Then
                    startLocation.Y = endLocation.Y

                End If


                'به دليل اينکه طول نمی تواند منفی باشد
                s.X = Math.Abs(s.X)
                'به دليل اينکه عرض نمی تواند منفی باشد
                s.Y = Math.Abs(s.Y)

                'قطر دايره با طول ضلع بزرگتر چهارضلعی ست می کند
                If s.X > s.Y Then
                    s.Y = s.X
                Else
                    s.X = s.Y
                End If

                'رسم نيم دايره با قرار دادن 0 درجه  به عنوان درجه ی شروع ترسيم و 
                ' -180به عنوان درجه ی پایان ترسيم 
                g.DrawArc(PenPoint, New Rectangle(startLocation, s), 0, -180)


                'ترسيم متوازی الاضلاع
            ElseIf ParallelepipedRadioButton.Checked Then
                'برای ترسيم متوازی الاضلاع از يک چهار ضلعی استفاده می شود که محاط بر متوازی الاضلاع است
                'طول متوازی الاضلاع با طول چهار ضلعی برابر است و برای رسم ضلع عرضی متوازی الاضلاع از انتهای 
                'يک گوشه طول يک ضلع افقی به اندازه يک پنجم طول جلو می رويم و آن را به گوشه ی متناظر  ضلع افقی 
                'ديگر متصل می کنيم و برای ضلع عرضی ديگر نيز همين کار می کنيم


                'موقعيت ابتدا در رويدا
                'PictureBox1_MouseDown
                'محاسبه و در متغيير
                'startLocation
                'ذخيره می شود

                'موقعيت انتهای چهارضلعی
                endLocation = e.Location

                'با استفاده از موقعيت ابتدا و انتها طول و عرض چهار ضلعی را بدست می آوريم
                Dim s As Point

                'محاسبه طول
                s.X = endLocation.X - startLocation.X
                'به دليل اينکه طول نمی تواند منفی باشد
                'موقعيت 
                'X
                'ابتدا و انتها را جابجا می کنيم
                'اگر طول بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن طول ,طول در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'X
                'نقاط ابتدا و انتها جابجا می شود
                If s.X < 0 Then
                    Dim tmp As Integer = startLocation.X
                    startLocation.X = endLocation.X
                    endLocation.X = tmp
                End If

                'محاسبه عرض
                s.Y = endLocation.Y - startLocation.Y

                'به دليل اينکه عرض نمی تواند منفی باشد
                'موقعيت 
                'Y
                'ابتدا و انتها را جابجا می کنيم
                'اگر عرض بدست امده نسبت به نقطه ابتدايي منفی بدست آمد
                'بعد از مثبت کردن عرض ,عرض در خلاف جهت خواسته شده رسم می شود 
                'به همين دليل مختصات 
                'Y
                'نقاط ابتدا و انتها جابجا می شود
                If s.Y < 0 Then
                    Dim tmp As Integer = startLocation.Y
                    startLocation.Y = endLocation.Y
                    endLocation.Y = tmp
                End If

                'به دليل اينکه طول نمی تواند منفی باشد
                s.X = Math.Abs(s.X)
                'به دليل اينکه عرض نمی تواند منفی باشد
                s.Y = Math.Abs(s.Y)



                Dim p(3) As Point

                p(0) = New Point(startLocation.X + s.X / 5, startLocation.Y)
                p(1) = New Point(startLocation.X + s.X, startLocation.Y)

                p(2) = New Point(endLocation.X - s.X / 5, endLocation.Y)
                p(3) = New Point(endLocation.X - s.X, endLocation.Y)

                'رسم متوازی الاضلاع
                g.DrawPolygon(PenPoint, p)



                'پر کردن ناحيه دلخواه
            ElseIf FillRadioButton.Checked Then
                FillRegion(e.X, e.Y, CurrentColor)


                'ترسيم متن مورد نظر
            ElseIf TextRadioButton.Checked Then
                'گرفتن متن مورد نظر از جعبه متنی
                Dim txt As String = Me.TextDrawTextBox.Text

                'ترسيم متن مورد نظر
                g.DrawString(txt, CurrentFont, New Drawing2D.HatchBrush(Drawing2D.HatchStyle.BackwardDiagonal, CurrentColor), e.X, e.Y)

            End If

        End If

        'مشخص می کند که ديگری چيزی به حرکت ماموس نبايد رسم شود مگر اينکه مقدار اين متغيير
        'True
        'شود
        drawing = False


        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()

    End Sub


    'مقدار دهی اوليه متغيير ها
    Private Sub PaintForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        X = Me.Size.Width
        Y = Me.Size.Height

        PictureBox1.Location = New System.Drawing.Point(25, Y / 20)
        GroupBox1.Location = New System.Drawing.Point((X / 2) + 150, Y / 20)
        Label1.Location = New System.Drawing.Point((X / 2), Y / 10)


        CurrentFont = Me.Font
        FontButton.Text = CurrentFont.ToString

        Me.ColorButton.BackColor = Color.Blue
        Me.Color2Button.BackColor = Color.LightSkyBlue

        'با اين دستور مشخص می شود که تمامی دستورات گرافيکی بايد بر روی متغيير
        'LastImage
        'اعمال شوند 
        g = Graphics.FromImage(LastImage)

        'پاک کردن صفحه با رنگ سفيد
        g.Clear(Color.White)

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()

        'ساختن قلم ترسيم به ضخامت و رنگ مورد نظر
        ReloadPen(PenWidth, CurrentColor)


    End Sub


    'تعيين رنگ 1 قلم 
    Private Sub ColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorButton.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CurrentColor = ColorDialog1.Color
            Me.ColorButton.BackColor = CurrentColor
            ReloadPen(PenWidth, CurrentColor)
        End If



    End Sub

    'تعيين رنگ 2  
    Private Sub Color2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color2Button.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CurrentColor2 = ColorDialog1.Color
            Me.Color2Button.BackColor = CurrentColor2
        End If
    End Sub


    'پاک کردن صفحه با رنگ سفيد
    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ClearScreen()
    End Sub
    'پاک کردن صفحه با رنگ سفيد
    Sub ClearScreen()
        'LastImage = New Bitmap(501, 501)
        g = Graphics.FromImage(LastImage)
        g.Clear(Color.White)
        UpdateImage()
    End Sub

    'ذخيره در يک فايل
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If SavedFileAddress = "" Then
            SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SavedFileAddress = SaveFileDialog1.FileName



                LastImage.Save(SavedFileAddress)
                Me.Text = SaveFileDialog1.FileName
            End If

        Else
            LastImage.Save(SavedFileAddress)
            Me.Text = SaveFileDialog1.FileName
        End If



    End Sub

    'ذخيره در يک فايل جديد
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SavedFileAddress = SaveFileDialog1.FileName

            LastImage.Save(SavedFileAddress)
            Me.Text = SaveFileDialog1.FileName
        End If
    End Sub


    'پيش نياز رسم مثلث تا با رسم چند ضلعی تداخل پيدا نکند
    Private Sub TriangleRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriangleRadioButton.CheckedChanged
        'برای رسم يک مثلث جديد بايد اين متغيير با اين مقدار , مقدار دهی اوليه شود
        TempLocation = New Point(-1, -1)
    End Sub


    'ضخامتِ قلم1
    Private Sub P1RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P1RadioButton.CheckedChanged
        PenWidth = 1.0F
        ReloadPen(PenWidth, CurrentColor)

    End Sub

    'ضخامتِ قلم2
    Private Sub P2RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P2RadioButton.CheckedChanged
        PenWidth = 5.0F
        ReloadPen(PenWidth, CurrentColor)

    End Sub

    'ضخامتِ قلم3
    Private Sub P3RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P3RadioButton.CheckedChanged
        PenWidth = 10.0F
        ReloadPen(PenWidth, CurrentColor)

    End Sub


    'ذخيره يک کپی از
    'LastImage
    'در
    'M1
    Private Sub M1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M1ToolStripMenuItem.Click

        M1 = LastImage.Clone()

    End Sub

    'ذخيره يک کپی از
    'LastImage
    'در
    'M2
    Private Sub M2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2ToolStripMenuItem.Click
        M2 = LastImage.Clone()
    End Sub

    'ذخيره يک کپی از
    'LastImage
    'در
    'M3
    Private Sub M3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M3ToolStripMenuItem.Click
        M3 = LastImage.Clone()
    End Sub

    'ذخيره يک کپی از
    'LastImage
    'در
    'M4
    Private Sub M4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M4ToolStripMenuItem.Click
        M4 = LastImage.Clone()
    End Sub


    'بازيابی تصوير ذخيره شده در
    'M1
    'به
    'LastImage
    'و نمايش آن
    Private Sub S1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S1ToolStripMenuItem.Click


        'قرار دادن يک کپی از 
        'M1
        'در 
        'LastImage 
        LastImage = M1.Clone


        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()
    End Sub

    'بازيابی تصوير ذخيره شده در
    'M2
    'به
    'LastImage
    'و نمايش آن
    Private Sub S2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S2ToolStripMenuItem.Click

        'قرار دادن يک کپی از 
        'M2
        'در 
        'LastImage 
        LastImage = M2.Clone

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()
    End Sub

    'بازيابی تصوير ذخيره شده در
    'M3
    'به
    'LastImage
    'و نمايش آن
    Private Sub S3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S3ToolStripMenuItem.Click
        'قرار دادن يک کپی از 
        'M3
        'در 
        'LastImage 
        LastImage = M3.Clone

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()
    End Sub

    'بازيابی تصوير ذخيره شده در
    'M4
    'به
    'LastImage
    'و نمايش آن
    Private Sub S4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S4ToolStripMenuItem.Click
        'قرار دادن يک کپی از 
        'M4
        'در 
        'LastImage 
        LastImage = M4.Clone

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()
    End Sub


    'يک تصوير جديد خالی را ايجاد می نمايد
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        'قبل از ايجاد تصوير جديد آيا کاربر می خواهد کار قبلی را ذخيره کند يا نه
        If SavedFileAddress = "" Then
            Dim result As Integer = MsgBox("آيا می خواهيد کار قبلی را در يک فايل ذخيره نماييد", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then


                'ذخيره در يک فايل جديد
                SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SavedFileAddress = SaveFileDialog1.FileName

                    LastImage.Save(SavedFileAddress)
                    Me.Text = SaveFileDialog1.FileName
                End If

            End If
        End If

        'پاک کردن صفحه با رنگ سفيد
        g.Clear(Color.White)

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()


        'با قرار دادن اين مقدار در اين متغيير باعث می شود هنگامی که از منوی 
        'File
        'گزينه ی
        'Save
        'را انتخاب کنيم برنامه در خواست يک مکان جديد و يک فاطل جديد را برای ذخيره 
        'کردن تصوير نمايد
        SavedFileAddress = ""
    End Sub


    'خروج از برنامه
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If SavedFileAddress = "" Then
            Dim result As Integer = MsgBox("آيا می خواهيد قبل از خروج تصوير را در يک فايل ذخيره نماييد", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then


                'ذخيره در يک فايل جديد
                SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SavedFileAddress = SaveFileDialog1.FileName

                    LastImage.Save(SavedFileAddress)
                    Me.Text = SaveFileDialog1.FileName
                End If

            ElseIf result = MsgBoxResult.No Then
                End
            End If
        End If
    End Sub


    'نمايش جعبه متنی برای نوشتن متن مورد نظر در تصوير
    'يا پنهان سازی آن
    Private Sub TextRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRadioButton.CheckedChanged
        If Me.TextRadioButton.Checked = True Then
            Me.TextDrawTextBox.Visible = True
            'FontButton.Visible = True
        Else
            Me.TextDrawTextBox.Visible = False
            'FontButton.Visible = False
        End If
    End Sub


    'قلم يا فونت نوشتاری جاری برنامه را تعيين می کند
    Private Sub FontButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontButton.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CurrentFont = FontDialog1.Font
            FontButton.Text = CurrentFont.ToString
        End If
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearScreen()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SavedFileAddress = "" Then
            Dim result As Integer = MsgBox("آيا می خواهيد کار قبلی را در يک فايل ذخيره نماييد", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then


                'ذخيره در يک فايل جديد
                SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SavedFileAddress = SaveFileDialog1.FileName

                    LastImage.Save(SavedFileAddress)
                    Me.Text = SaveFileDialog1.FileName
                End If

            End If
        End If

        'پاک کردن صفحه با رنگ سفيد
        g.Clear(Color.White)

        'به روز رسانی تصوير 
        'باعث می شود تا دستورات   اعمال شده روی تصوير و در خروجی نمايش داده شود
        UpdateImage()


        'با قرار دادن اين مقدار در اين متغيير باعث می شود هنگامی که از منوی 
        'File
        'گزينه ی
        'Save
        'را انتخاب کنيم برنامه در خواست يک مکان جديد و يک فاطل جديد را برای ذخيره 
        'کردن تصوير نمايد
        SavedFileAddress = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp |JPEG File (*.jpg)|*.jpg"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SavedFileAddress = SaveFileDialog1.FileName
            File.Exists(SaveFileDialog1.FileName)
            LastImage.Save(SavedFileAddress)
            Me.Text = SaveFileDialog1.FileName
            Button6.Enabled = True
            Form24.TextBox8.Text = SavedFileAddress
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If SavedFileAddress = "" Then
            Dim result As Integer = MsgBox("آيا می خواهيد قبل از خروج تصوير را در يک فايل ذخيره نماييد", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then


                'ذخيره در يک فايل جديد
                SaveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SavedFileAddress = SaveFileDialog1.FileName

                    LastImage.Save(SavedFileAddress)
                    Me.Text = SaveFileDialog1.FileName
                End If
                Form1.Show()
                Close()
            ElseIf result = MsgBoxResult.No Then
                Form1.Show()
                Close()
            End If
        End If
    End Sub
    Private Sub GroupBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseDown
        BL = True
    End Sub
    Private Sub GroupBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseMove
        If e.Y <= 20 And e.X <= 25 Then
            GroupBox1.Cursor = Cursors.SizeAll
        Else
            GroupBox1.Cursor = Cursors.Default
        End If
        If BL And e.Y <= 20 And e.X <= 25 Then
            GroupBox1.Location = New Point((GroupBox1.Location.X) + e.X, (GroupBox1.Location.Y) + e.Y)
        End If
    End Sub
    Private Sub GroupBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseUp
        BL = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim PrintPreviewDialog1 As New PrintPreviewDialog
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Show()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim b As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.DrawToBitmap(b, New Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height))
        e.Graphics.DrawImage(b, New Point(0, 0))
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form24.PictureBox1.Image = Image.FromFile(Form24.TextBox8.Text)
        Form24.Button5.Enabled = True

        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection

        address = Form1.TextBox3.Text
        ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
    "atabase Password=" + Form14.TextBox10.Text + "")
        ocm.Connection = ocn
        ocm.CommandText = "update DarkhastLO SET IMGADR='" & Form24.TextBox8.Text & "' where (num='" & 1 & "')"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.CommandText = "update DarkhastLO SET NUM='" & 0 & "' where (num='" & 1 & "')"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
    End Sub
End Class