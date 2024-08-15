# Descri��o

Construa uma aplica��o que exponha uma api web que recebe por parametros um JWT (string) e verifica se � valida conforme regras abaixo:

- Deve ser um JWT v�lido
- Deve conter apenas 3 claims (Name, Role e Seed)
- A claim Name n�o pode ter car�cter de n�meros
- A claim Role deve conter apenas 1 dos tr�s valores (Admin, Member e External)
- A claim Seed deve ser um n�mero primo.
- O tamanho m�ximo da claim Name � de 256 caracteres.

#  Defini��o
Input: Um JWT (string).  
Output: Um boolean indicando se a valido ou n�o.

Use a linguagem de programa��o que considera ter mais conhecimento.

# Massa de teste 

### Caso 1:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg
```
Saida:
```
verdadeiro
```
Justificativa:
Abrindo o JWT, as informa��es contidas atendem a descri��o:
```json
{
  "Role": "Admin",
  "Seed": "7841",
  "Name": "Toninho Araujo"
}
```

### Caso 2:
Entrada:
```
eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg
```
Saida:
```
falso
```
Justificativa:
JWT invalido

### Caso 3:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs
```
Saida:
```
falso
```
Justificativa:
Abrindo o JWT, a Claim Name possui caracter de n�meros
```json
{
  "Role": "External",
  "Seed": "72341",
  "Name": "M4ria Olivia"
}
```

### Caso 4:
Entrada:
```
eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY
```
Saida:
```
falso
```
Justificativa:
Abrindo o JWT, foi encontrado mais de 3 claims.
```json
{
  "Role": "Member",
  "Org": "BR",
  "Seed": "14627",
  "Name": "Valdir Aranha"
}
```
## Pontos que daremos maior aten��o

- Testes de unidade / integra��o
- Abstra��o, acoplamento, extensibilidade e coes�o
- Design de API
- SOLID
- Documenta��o da solu��o no *README* 
- Commits realizados durante a constru��o
- Observability (Logging/Tracing/Monitoring)

## Demais Itens

- Containeriza��o da aplica��o
- Helm Chart em um cluster de Kubernetes/ECS/FARGATE
- Reposit�rio no GitHub.
- Deploy Automatizado para Infra-Estrutura AWS
- scripts ci/cd
- cole��es do Insomnia ou ferramentas para execu��o
- Provisione uma infraestrutura na AWS com OpenTerraform
- expor a api em algum provedor de cloud (aws, azure...)
- Uso de Engenharia de Prompt.

### Sobre a documenta��o

Nesta etapa do processo seletivo queremos entender as decis�es por tr�s do c�digo, portanto � fundamental que o *README* tenha algumas informa��es referentes a sua solu��o.

Algumas dicas do que esperamos ver s�o:

- Instru��es b�sicas de como executar o projeto;
- Detalhes da descri��o dos metodos
- Caso algo n�o esteja claro e voc� precisou assumir alguma premissa, quais foram e o que te motivou a tomar essas decis�es.

## Como esperamos receber sua solu��o

Esta etapa � eliminat�ria, e por isso esperamos que o c�digo reflita essa import�ncia.

Se tiver algum imprevisto, d�vida ou problema, por favor entre em contato com a gente, estamos aqui para ajudar.

Nos envie o *link de um repo p�blico* com a sua solu��o