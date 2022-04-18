import React, { useState, useEffect } from 'react';
import { makeStyles } from '@mui/styles';
import TextField from '@mui/material/TextField';
import fluxoCaixaService from '../../Services/fluxocaixaService';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputAdornment from '@mui/material/InputAdornment';
import AddCircleIcon from '@mui/icons-material/AddCircle';

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
    edicao: {
        width: '70%',
        height: 50,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
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
    btnIncluir: {
        height: 35,
        width: 35,
        border: '1px solid #999',
        borderRadius: 5,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        cursor: 'pointer',
        '&:hover .MuiSvgIcon-root': {
            color: '#999',
        },
    }
});

export default () => {
    const classes = useStyles();
    const [lista, setLista] = useState([]);
    const [dateValue, setDateValue] = useState(null);
    const [tipo, setTipo] = useState('');
    const [descMovimento, setDescMovimento] = useState('');
    const [valor, setValor] = useState();

    const handleChange = (event) => {
        setTipo(event.target.value);
    };

    const getMovimentos = async () => {
        const lista = await fluxoCaixaService.getMovimentos();
        setLista(lista);
    }

    const createMovimento = async () => {

        const movimento = {
            dt_movimento : dateValue,
            tp_movimento : tipo,
            descricao : descMovimento,
            vl_movimento : valor
        }

        await fluxoCaixaService.createMovimento(movimento);
        getMovimentos();
        LimpaCamposEdicao();
    }

    function LimpaCamposEdicao(){
        setDateValue(null);
        setTipo('');
        setDescMovimento('');
        setValor('');
    }

    useEffect(() => {
        getMovimentos();
    }, []);

    

    return (
        <div className={classes.root}>
            <div className={classes.titulo}>
                Fluxo de Caixa - Lançamentos de Débitos e Créditos
            </div>
            <div className={classes.edicao}>
                <div style={{ marginRight: 10 }}>
                    <TextField
                        type="date"
                        id="outlined-basic"
                        label="Data"
                        variant="outlined"
                        margin="dense"
                        size="small"
                        value={dateValue}
                        onChange={(e) => setDateValue(e.target.value)}
                        inputProps={{ style: { textTransform: "uppercase" } }}
                        InputLabelProps={{ shrink: true, }}
                        style={{ width: 160 }}
                    />
                </div>
                <div style={{ marginRight: 10 }}>
                    <FormControl fullWidth>
                        <InputLabel id="demo-simple-select-label">Tipo</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="tipo"
                            value={tipo}
                            label="Tipo"
                            onChange={handleChange}
                            size="small"
                            margin="dense"
                            InputLabelProps={{ shrink: true }}
                            style={{ width: 150, marginTop: 3 }}
                        >
                            <MenuItem value="DEBITO">DEBITO</MenuItem>
                            <MenuItem value="CREDITO">CREDITO</MenuItem>
                        </Select>
                    </FormControl>
                </div>
                <div style={{ marginRight: 10 }}>
                    <TextField
                        id="outlined-basic"
                        label="Descrição"
                        variant="outlined"
                        margin="dense"
                        size="small"
                        value={descMovimento}
                        onChange={(e) => setDescMovimento(e.target.value)}
                        inputProps={{ style: { textTransform: "uppercase" } }}
                        InputLabelProps={{ shrink: true, }}
                        style={{ width: 330 }}
                    />
                </div>
                <div style={{ marginRight: 10 }}>
                    <FormControl variant="outlined">
                        <InputLabel htmlFor="outlined-adornment-amount">Valor</InputLabel>
                        <OutlinedInput
                            id="outlined-adornment-amount"
                            value={valor}
                            onChange={(e) => setValor(e.target.value)}
                            startAdornment={<InputAdornment position="start">$</InputAdornment>}
                            label="Valor"
                            margin="dense"
                            size="small"
                            style={{ width: 90 }}
                        />
                    </FormControl>
                </div>
                <div className={classes.btnIncluir} onClick={createMovimento}>
                    <AddCircleIcon />
                </div>
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