export const environment = {
  production: true,
  // GOOGLE_MAP_API_KEY: 'AIzaSyDv6iQmIaaa6ibw0UQy_JARZoYNaZXWfq8'

  GOOGLE_MAP_API_KEY: window["env"]["GOOGLE_MAP_API_KEY"] || "default",
  RANGE: window["env"]["RANGE"] || "1000"
};
