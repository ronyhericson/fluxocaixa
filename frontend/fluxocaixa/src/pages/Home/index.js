import React, { useState, useEffect } from 'react';
import { makeStyles } from '@mui/styles';


import fluxoCaixaService from '../../Services/fluxocaixaService';

const useStyles = makeStyles({
    root: {
        width: '100%',
        height: 'calc(100vh - 10px)',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        display: 'flex',
        flexDirection: 'column',
    },
    titulo: {
        display: 'flex',
        fontSize: 28,
        fontWeight: 600,
    },
    gridLancamentos: {
        width: '60%',
        height: 'calc(100% - 50px)',
        display: 'flex',
        flexDirection: 'column',
        border: '1px solid #999',
        borderRadius: 10,
    },
    gridHeader: {
        width: '100%',
        height: 35,
        borderBottom: '1px solid #999',
        display: 'flex',
    },
    row: {
        width: '100%',
        height: 35,
        borderBottom: '1px solid #999',
        display: 'flex',
        cursor: 'pointer',
        '&:hover': {
            backgroundColor: '#EDEDED'
        }
    },
    columnHeader: {
        width: '100%',
        height: '100%',
        fontSize: 18,
        fontWeight: 600,
        color: '#999',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        borderRight: '1px solid #999',
        borderBottom: '1px solid #999',
    },
    columnRow: {
        width: '100%',
        height: '100%',
        fontSize: 14,        
        color: '#999',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        borderRight: '1px solid #999',
        borderBottom: '1px solid #999',
    },
    gridRows: {

    }
});

export default () => {
    const classes = useStyles();
    const [lista, setLista] = useState([]);

    const getMovimentos = async () => {
        const lista = await fluxoCaixaService.getMovimentos();
        setLista(lista);
    }

    useEffect(() => {
        getMovimentos();
    }, []);


    return (
        <div className={classes.root}>
            <div className={classes.titulo}>
                Fluxo de Caixa - Lançamentos de Débitos e Créditos
            </div>
            <div className={classes.gridLancamentos}>
                <div className={classes.gridHeader}>
                    <div className={classes.columnHeader}>Data Lançamento </div>
                    <div className={classes.columnHeader}>Tipo </div>
                    <div className={classes.columnHeader}>Descrição </div>
                    <div className={classes.columnHeader}>Valor </div>
                    <div className={classes.columnHeader} style={{ borderRight: '0px' }}>Saldo Atual </div>
                </div>
                {
                    (lista || []) && lista.map((item) => {
                        return (
                            <div className={classes.row}>
                                <div className={classes.columnRow}>{item.dt_movimento}</div>
                                <div className={classes.columnRow}>{item.tp_movimento}</div>
                                <div className={classes.columnRow}>{item.descricao}</div>
                                <div className={classes.columnRow}>{item.vl_movimento}</div>
                                <div className={classes.columnRow} style={{ borderRight: '0px' }}>{item.vl_saldoatual}</div>
                            </div>
                        )
                    })
                }
            </div>
        </div>
    )
}