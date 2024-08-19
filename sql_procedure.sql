Create proc sp_ThongKe
as
BEGIN
  DECLARE @Sotruycapgannhat int
  DECLARE @count int
  SELECT @count = COUNT(*) FROM ThongKes
  IF @count IS NULL SET @count=0
  IF @count=0
    INSERT INTO ThongKes(ThoiGian,SoTruyCap)
	Values(GETDATE(),1)
  ELSE
    BEGIN
	  DECLARE @ThoiGianGanNhat datetime
	  SELECT @Sotruycapgannhat=tk.SoTruyCap, @ThoiGianGanNhat=tk.ThoiGian FROM ThongKes tk
	  WHERE tk.Id=(SELECT MAX(tk2.Id) FROM ThongKes tk2)
	  IF @Sotruycapgannhat IS NULL SET @Sotruycapgannhat=0
	  IF @ThoiGianGanNhat IS NULL SET @ThoiGianGanNhat=GETDATE()
	  --Nếu chuyển sang ngày mới sau 12h đêm
	  --Nếu chưa chuyển sang ngày mới thì update
	  IF DAY(@ThoiGianGanNhat)=DAY(GETDATE())
	     BEGIN
		   UPDATE ThongKes
		   SET SoTruyCap=@Sotruycapgannhat+1, ThoiGian=GETDATE()
		   WHERE Id=(SELECT MAX(tk2.Id) From ThongKes tk2)
		 END
	  --Nếu đã sang ngày mới thì thêm 1 bản ghi mới
	  ELSE
	     INSERT INTO ThongKes(ThoiGian,SoTruyCap)
	     Values(GETDATE(),1)
	END
	-- Thống kê hôm nay, hôm qua, tuần này, tuần trước, tháng này, tháng trước
	DECLARE @Homnay int
	SET @Homnay=DATEPART(DW,GETDATE());
	SELECT @Sotruycapgannhat=SoTruyCap, @ThoiGianGanNhat=ThoiGian From ThongKes
	WHERE Id=(SELECT MAX(Id) From ThongKes)
	-- Số truy cập ngày hôm qua
	DECLARE @TruyCapHomQua bigint
	SELECT @TruyCapHomQua=ISNULL(SoTruyCap,0), @ThoiGianGanNhat=ThoiGian From ThongKes
	WHERE CONVERT(nvarchar(20),ThoiGian,103)=CONVERT(nvarchar(20),GETDATE()-1,103)
	IF @TruyCapHomQua IS NULL SET @TruyCapHomQua=0

	--Truy cập đầu tuần này
	DECLARE @DauTuanNay datetime
	SET @DauTuanNay = DATEADD(wk,DATEDIFF(wk,6,GETDATE()),6)
	--Tính ngày đầu của tuần trước tính từ thời điểm 00:00))
	DECLARE @NgayDauTuanTruoc datetime
	SET @NgayDauTuanTruoc=CAST(CONVERT(nvarchar(30),DATEADD(dd,-(@Homnay+6),GETDATE()),101) AS datetime)
	--Tính ngày cuối tuần trước tính đến 24h ngày cuối tuần
	DECLARE @NgayCuoiTuanTruoc datetime
	SET @NgayCuoiTuanTruoc=CAST(CONVERT(nvarchar(30),DATEADD(dd,-@Homnay,GETDATE()),101) + '23:59:59' AS datetime)


	-- Số truy cập tuần này
	DECLARE @TruyCapTuanNay bigint
	SELECT @TruyCapTuanNay=ISNULL(SUM(SoTruyCap),0) FROM ThongKes
	WHERE ThoiGian BETWEEN @DauTuanNay AND GETDATE()
	-- Số truy cập tuần trước
	DECLARE @TruyCapTuanTruoc bigint
	SELECT @TruyCapTuanTruoc=ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk
	WHERE ttk.ThoiGian BETWEEN @NgayDauTuanTruoc AND @NgayCuoiTuanTruoc
	-- Số truy cập tháng này
	DECLARE @TruyCapThangNay bigint
	SELECT @TruyCapThangNay=ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk
	WHERE MONTH(ttk.ThoiGian)=MONTH(GETDATE())
	-- Số truy cập tháng trước
	DECLARE @TruyCapThangTruoc bigint
	SELECT @TruyCapThangTruoc=ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk
	WHERE MONTH(ttk.ThoiGian)=MONTH(GETDATE())-1

	--Tính tổng số
	DECLARE @TongSo bigint
	SELECT @TongSo=ISNULL(SUM(SoTruyCap),0) FROM ThongKes ttk
	SELECT @Sotruycapgannhat AS HomNay,
	@TruyCapHomQua AS HomQua,
	@TruyCapTuanNay AS TuanNay,
	@TruyCapTuanTruoc AS TuanTruoc,
	@TruyCapThangNay AS ThangNay,
	@TruyCapThangTruoc AS ThangTruoc,
	@TongSo AS TatCa
END


