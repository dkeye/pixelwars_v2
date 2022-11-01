<template>
    {{j}}
    <canvas ref='myCanvas' id="mainCanvas">
    </canvas>
</template>

<script>
 
export default {
        data() {
            return {

            };
        },

        props: {
            j: {
                type: Number,
            }
        },

        beforeMount() {
            console.log('beforeMount');
        },

        mounted() {
            const ctx = this.$refs.myCanvas.getContext('2d') 
            // ctx.fillStyle = 'green';
            // ctx.fillRect(10, 0, 150, 100);
            for (let i = 0; i < 50; i++) {
                for (let j = 0; j < 50; j++) {
                    ctx.fillStyle = `rgb(
                        ${Math.floor(255 - 16 * i)},
                        ${Math.floor(255 - 16 * j)},
                        100)`;
                    ctx.fillRect(j * 10, i * 10, 10, 10);
                }
            } 
            console.log('mounted\n', ctx)
        },

        beforeUpdate() {
            console.log('beforeUpdate');
        },

        updated() {
            console.log('updated');
        }


    };


</script>

<style scoped>
    #mainCanvas {
        width: 500px;
        height: 500px;
        border: 2px solid black;
        background: #FFFFFF;
    }
</style>