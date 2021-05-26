/* eslint-disable jsx-a11y/label-has-associated-control */
/* eslint-disable react/jsx-props-no-spreading */
import React from 'react';
import { MainHead } from '@Components';
import { Global } from '@Components/basic';
import { useForm, Controller } from 'react-hook-form';
import { Input, Button } from '@material-ui/core';
import { Ff } from './styled';

export const MainLayout: React.FunctionComponent = (): JSX.Element => {
  const {
    handleSubmit,
    formState: { errors },
    control,
  } = useForm();
  const onSubmit = (data) => console.log(data);
  return (
    <>
      <MainHead />
      <span>Menu: </span>
      <br />
      <form onSubmit={handleSubmit(onSubmit)}>
        <Ff>
          <label htmlFor="A">
            A:
            <Controller
              name="a"
              control={control}
              defaultValue={''}
              rules={{ required: true }}
              render={({ field }) => <Input {...field} />}
            />
          </label>
          <label htmlFor="B">
            B:
            <Controller
              name="b"
              control={control}
              defaultValue={''}
              rules={{ required: true }}
              render={({ field }) => <Input {...field} />}
            />
          </label>
          <label htmlFor="C">
            C:
            <Controller
              name="c"
              control={control}
              defaultValue={''}
              rules={{ required: true }}
              render={({ field }) => <Input {...field} />}
            />
          </label>
          {errors.exampleRequired && <span>This field is required</span>}
          <br />

          <Button type="submit" className="submit">
            submit
          </Button>
        </Ff>
      </form>
      <br />
      <Global />
    </>
  );
};
