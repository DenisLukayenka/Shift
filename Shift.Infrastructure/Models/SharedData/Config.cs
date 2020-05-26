namespace Shift.Infrastructure.Models.SharedData
{
	public static class Config
	{
		public const string InvalidAuth = "Неверное имя пользователя и/или пароль";
		public const string NotFound = "Страница не найдена";
		public const string AccessForbiden = "Для просмотра страницы недостаточно прав";
		public const string BadRequest = "Неверный запрос!";
		public const string LoginExist = "Пользователь с таким логином уже зарегистрирован";
		public const string SaveSuccess = "Сохранение прошло успешно";
		public const string UserNotFound = "Пользователь не найден";

		public const string Issuer = "http://localhost:4200";
		public const string Audience = "http://localhost:50280";
		public const string Secret = "qwertgdhgy@1gfdhhhfd11";
	}
}
