<template> 
  <div id="root">
    <h1> Pixel warS </h1>
    <Field/>
  </div>
</template>

<script>
  import Field from './components/Field.vue';
  export default {
    components: { Field },

    data() {
        return {
        };
    },
  }
</script>

<style>
  h1 {
    font-size: 35px;
    line-height: 30px;
    letter-spacing: 8px;
    position: absolute;
    top: 50px;
    font-family: monospace;
  }
  #root {
    background: #ddd1d1;
    width: 100%;
    height: 700px;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }
</style>
