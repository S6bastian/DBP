const express = require('express');
const { graphqlHTTP } = require('express-graphql');
const { buildSchema } = require('graphql');
const axios = require('axios');

// Definir el esquema GraphQL
const schema = buildSchema(`
  type Cocktail {
    idDrink: String!
    strDrink: String!
    strCategory: String!
    strInstructions: String!
  }

  type Query {
    randomCocktail: Cocktail
  }
`);

// Resolver para la consulta 'randomCocktail'
const getRandomCocktail = async () => {
  try {
    const response = await axios.get('https://www.thecocktaildb.com/api/json/v1/1/random.php');
    const cocktail = response.data.drinks[0];
    return {
      idDrink: cocktail.idDrink,
      strDrink: cocktail.strDrink,
      strCategory: cocktail.strCategory,
      strInstructions: cocktail.strInstructions,
    };
  } catch (error) {
    console.error(error);
    throw new Error('Error al obtener un cóctel aleatorio');
  }
};

// Root resolver
const root = {
  randomCocktail: getRandomCocktail,
};

// Crear una aplicación Express
const app = express();

// Configurar el endpoint GraphQL
app.use('/graphql', graphqlHTTP({
  schema: schema,
  rootValue: root,
  graphiql: true, // Habilitar el GraphiQL UI para probar las consultas
}));

// Iniciar el servidor
app.listen(4000, () => {
  console.log('Servidor GraphQL en ejecución en http://localhost:4000/graphql');
});
