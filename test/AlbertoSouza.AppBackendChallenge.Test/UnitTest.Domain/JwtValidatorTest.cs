namespace AlbertoSouza.AppBackendChallenge.Domain.Test
{
    public class JwtValidatorTest
    {
        private readonly Dictionary<int, (string expectedMessage, string jwtItem)> _mappedCases = new()
        {
            { 0, ("Token JWT válido", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg") },
            { 1, ("Token JWT inválido", "XPTO-InvalidData") },
            { 2, ("Token JWT inválido", "eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg") },
            { 3, ("A claim Name não pode conter números", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs") } ,
            { 4, ("A claim Name não pode ter mais de 256 caracteres", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTG9yZW0gaXBzdW0gZG9sb3Igc2l0IGFtZXQsIGNvbnNlY3RldHVyIGFkaXBpc2NpbmcgZWxpdCwgc2VkIGRvIGVpdXNtb2QgdGVtcG9yIGluY2lkaWR1bnQgdXQgbGFib3JlIGV0IGRvbG9yZSBtYWduYSBhbGlxdWEuIFV0IGVuaW0gYWQgbWluaW0gdmVuaWFtLCBxdWlzIG5vc3RydWQgZXhlcmNpdGF0aW9uIHVsbGFtY28gbGFib3JpcyBuaXNpIHV0IGFsaXF1aXAgZXggZWEgY29tbW9kbyBjb25zZXF1YXQuIER1aXMgYXV0ZSBpcnVyZSBkb2xvciAuLi4ifQ.f5WdR8zvdVLVaVdIoD5xsK2JRis_KDfJ2DkjCogyXXU") } ,
            { 5, ("O token deve conter exatamente 3 claims", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY") },
            { 6, ("As claims Name, Role, Seed são obrigatórias", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lIjoiQWxiZXJ0byBTb3V6YSIsIlJvbGUiOiJFeHRlcm5hbCIsIlhwdG8tRGF0YSI6N30.KSg8qYdqyuHDUnTYaoblshNHV3Xn1iokrv-amOh-ywE") },
            { 7, ("A claim Role deve ser Admin, Member ou External", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQW5vbnltb3VzIiwiU2VlZCI6IjE0NjI3IiwiTmFtZSI6IlZhbGRpciBBcmFuaGEifQ.YC6_0lZ7KBer61G9Jh_mRHgwe6Zig4sAlo5nD9gZtI0") },
            { 8, ("A claim Seed deve ser um número primo", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MTIiLCJOYW1lIjoiVG9uaW5obyBBcmF1am8ifQ.HmprEmZro-hwb4dr3rHEA6mvHxSB7Ss8v-Job9ZT1cw") },
        };

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, false)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        [InlineData(7, false)]
        [InlineData(8, false)]
        public void GiveOneJwtData_WhenValidateJwt_ThenShouldReturnIsValidAndMessage(int caseId, bool expectedIsValid)
        {
            // Arrange / Give
            var jtw = _mappedCases[caseId].jwtItem;
            var expectedMessage = _mappedCases[caseId].expectedMessage;

            // Act / When
            var result = JwtValidator.ValidateJwt(jtw);

            // Assert / Then
            Assert.Equal(expectedIsValid, result.IsValid);
            Assert.Equal(expectedMessage, result.ValidationMessage);
        }
    }
}